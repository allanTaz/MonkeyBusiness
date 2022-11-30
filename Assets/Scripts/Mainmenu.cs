using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject pauseMenu;
   public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() 
    {
        Application.Quit();
    }

    public void UInable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    public void Pause()
    {
        Debug.Log("Game Paused");
        pauseMenu.SetActive(true);
    }
}
