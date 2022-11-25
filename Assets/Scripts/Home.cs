using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public GameObject btnPlay;
    public GameObject btnMusic;
  //  public GameObject btnQuit;



    // Start is called before the first frame update
    void Start()
    {
        btnPlay.GetComponent<Button>().onclick.Addlistener(_Play);
        btnMusic.GetComponent<Button>().onclick.Addlistener(_Music);
      //  btnQuit.GetComponent<Button>().onclick.Addlistener(_Quit);
    }

    //Play

    void _Play()
    {
        ScenceManager.LoadScene("FirstFight");
    }

   // void _Qiut()
    //{
      //  if UNITY_EDITOR
        //     UnityEditor.EditorApplication.isPlaying = false;
        //else
         //   Application.Quit();
        //endif
            
    //}


    // Update is called once per frame
    void Update()
    {

        
    }
}
