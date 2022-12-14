using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene Switcher - allows you to switch between any scene in your project
/// Developer: Dibbie
/// Email: mailto:strongstrenth@hotmail.com [for questions/help and inquires]
/// Website: http://www.simpleminded.x10host.com
/// Discord: https://discord.gg/33PFeMv
/// </summary>
public class SceneSwitcher : EditorWindow
{
    static bool buildFold = true;
    static bool projectFold = true;
    static string sceneLookup = "";

    static bool saveScene, cancelSave;
    static Vector2 scrollPos;

    static EditorWindow window;
    static bool searchByPath = false;

    string lastSearchInstance;
    int searchCount;

    public static void SearchFromHistory(SceneSearchHistory.SearchHistory search)
    {
        sceneLookup = search.search;
        searchByPath = search.searchByPath;

        GUI.SetNextControlName("SearchField");
        GUI.FocusControl("SearchField");
    }

    static void ReloadCachedReferences()
    {
        buildFold = EditorPrefs.GetBool("SSBuildFold", true);
        projectFold = EditorPrefs.GetBool("SSProjectFold", true);
        scrollPos = new Vector2(0f, EditorPrefs.GetFloat("SSScrollPosY", 0f));
        searchByPath = EditorPrefs.GetBool("SSSearchByPath", false);
    }
    
    static void UpdateCachedReferences()
    {
        EditorPrefs.SetBool("SSBuildFold", buildFold);
        EditorPrefs.SetBool("SSProjectFold", projectFold);
        EditorPrefs.SetFloat("SSScrollPosY", scrollPos.y);
        EditorPrefs.SetBool("SSSearchByPath", searchByPath);
    }

    [MenuItem("Scene Manager/Switch Scenes _%&s")]
    static void Init()
    {
        window = GetWindow(typeof(SceneSwitcher), false, "Switch Scene");
        window.minSize = new Vector2(600f, 505f);
        ReloadCachedReferences();
        window.Show();
    }

    [UnityEditor.Callbacks.DidReloadScripts]
    private static void OnScriptsReloaded()
    {
        ReloadCachedReferences();
    }

    void OnGUI()
    {
        if (window == null) { ReloadCachedReferences(); window = GetWindow(typeof(SceneSwitcher)); }

        GUILayout.Label("Search for Scene");
        GUILayout.BeginHorizontal(GUI.skin.FindStyle("Toolbar"));
        GUI.SetNextControlName("SearchField");
        sceneLookup = GUILayout.TextField(sceneLookup, GUI.skin.FindStyle("ToolbarSeachTextField"), GUILayout.Width(window.position.width - (string.IsNullOrEmpty(sceneLookup) ? 21f : 37f)));

        //search clear button
        if (!string.IsNullOrEmpty(sceneLookup))
        {
            if (GUILayout.Button("", GUI.skin.FindStyle("ToolbarSeachCancelButton")))
            {
                Unfocus();
            }
        }

        if (GUILayout.Button("", EditorStyles.toolbarDropDown, GUILayout.Width(15f)))
        {
            // create custom dropdown menu on button click
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Search By Path"), searchByPath == true, OnSearchFilterChanged, !searchByPath);
            menu.AddSeparator("");
            menu.AddItem(new GUIContent("Open Search History"), false, OnSearchHistoryOpened, null);

            menu.ShowAsContext();
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUILayout.Label("Active Scene: " + EditorSceneManager.GetActiveScene().name, EditorStyles.boldLabel);
        EditorGUILayout.Space();

        scrollPos = GUILayout.BeginScrollView(scrollPos);
        if (string.IsNullOrEmpty(sceneLookup)) //HashSet all scenes
        {
            GUIStyle style = EditorStyles.foldout;
            style.fontSize = 15;

            #region Scenes in Build
            List<string> disabledScenesInBuild = new List<string>();
            buildFold = EditorGUILayout.Foldout(buildFold, "Scenes In Build", true);

            if (buildFold)
            {
                //HashSet all ACTIVE scenes in Build Settings
                foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
                {
                    if (!scene.enabled) { disabledScenesInBuild.Add(scene.path); }
                    else
                    {
                        string scenePath = scene.path;
                        string sceneName = scenePath.Substring(scenePath.LastIndexOf("/") + 1).Replace(".unity", string.Empty);

                        EditorGUILayout.Space();
                        if (GUILayout.Button(sceneName)) { SwitchScenes(scenePath); Unfocus(); }
                        GUILayout.TextField("(" + scenePath + ")", EditorStyles.textField);
                    }
                }

                //HashSet all DISABLED scenes in Build Settings
                if (disabledScenesInBuild.Count > 0)
                {
                    GUILayout.Label("[DISABLED SCENES IN BUILD]");

                    for (int i = 0; i < disabledScenesInBuild.Count; i++)
                    {
                        string scenePath = disabledScenesInBuild[i];
                        string sceneName = scenePath.Substring(scenePath.LastIndexOf("/") + 1).Replace(".unity", string.Empty);

                        EditorGUILayout.Space();
                        if (GUILayout.Button(sceneName)) { EditorSceneManager.OpenScene(scenePath); Unfocus(); }
                        GUILayout.TextField("(" + scenePath + ")");
                    }
                }
            }
            #endregion

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            #region Scenes in Project
            string[] allScenePaths = AssetDatabase.FindAssets("t:scene");
            projectFold = EditorGUILayout.Foldout(projectFold, "Scenes In Project", true);

            if (projectFold)
            {
                for (int i = 0; i < allScenePaths.Length; i++)
                {
                    string scenePath = AssetDatabase.GUIDToAssetPath(allScenePaths[i]);
                    string sceneName = scenePath.Substring(scenePath.LastIndexOf("/") + 1).Replace(".unity", string.Empty);

                    EditorGUILayout.Space();
                    if (GUILayout.Button(sceneName)) { SwitchScenes(scenePath); }
                    GUILayout.TextField("(" + scenePath + ")");
                }
            }
            #endregion
        }
        else //HashSet scenes matching search results
        {
            string[] allScenes = AssetDatabase.FindAssets("t:scene");
            searchCount = 0;
            for (int i = 0; i < allScenes.Length; i++)
            {
                string scenePath = AssetDatabase.GUIDToAssetPath(allScenes[i]);
                string sceneName = scenePath.Substring(scenePath.LastIndexOf("/") + 1).Replace(".unity", string.Empty);
                if (sceneName.ToLower().Contains(sceneLookup.ToLower()) || (searchByPath && scenePath.ToLower().Contains(sceneLookup.ToLower())))
                {
                    EditorGUILayout.Space();
                    if (GUILayout.Button(sceneName)) { SwitchScenes(scenePath); Unfocus(); }
                    GUILayout.Label("(" + scenePath + ")");
                    searchCount++;
                }
            }
        }
        GUILayout.EndScrollView();

        // Add to search history
        if (!string.IsNullOrEmpty(sceneLookup) && GUI.GetNameOfFocusedControl() != "SearchField" && lastSearchInstance.ToLower() != sceneLookup.ToLower())
        {
            SceneSearchHistory.AddToHistory(this, new SceneSearchHistory.SearchHistory(sceneLookup, searchByPath, searchCount));
            lastSearchInstance = sceneLookup;
            GUI.SetNextControlName("SearchField");
            GUI.FocusControl("SearchField");
        }

        UpdateCachedReferences();
    }

    void OnInspectorUpdate()
    {
        this.Repaint();
    }

    void Unfocus()
    {
        // Add to search history
        SceneSearchHistory.AddToHistory(this, new SceneSearchHistory.SearchHistory(sceneLookup, searchByPath, searchCount));

        // Remove focus if cleared
        sceneLookup = "";
        GUI.FocusControl(null);
    }

    void OnSearchFilterChanged(object includePathInSearch)
    {
        searchByPath = (bool)includePathInSearch;
    }

    void OnSearchHistoryOpened(object obj)
    {
        SceneSearchHistory.Init(this);
    }

    public static void SwitchScenes(string scenePath)
    {
        Scene scene = EditorSceneManager.GetSceneByPath(scenePath);
        bool userWantsSave = false;

        if (EditorSceneManager.GetActiveScene().isDirty)
        {
            userWantsSave = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        if (userWantsSave || !EditorSceneManager.GetActiveScene().isDirty) { Load(scenePath); }
    }

    static void Load(string scenePath)
    {
        EditorSceneManager.OpenScene(scenePath);
    }
}
