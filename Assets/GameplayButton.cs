using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameplayButton : MonoBehaviour
{
    public GameObject main;
    public AudioSource buttonSource;
    public void gotohome()

    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void begin()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void Mutemusic()
    {
        buttonSource.Play();
        main.GetComponent<AudioSource>().enabled = false;
    }
}
