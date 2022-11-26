using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemanu : MonoBehaviour
{
    public GameObject PauseGame;

    public void PauseMenu()
    {
        PauseGame.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        PauseGame.SetActive(false);
        Time.timeScale = 1f;
    }

}
