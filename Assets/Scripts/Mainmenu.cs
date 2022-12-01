using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Mainmenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public AudioSource buttonSource;
 
    public GameObject player;



    public void PlayGame() 
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() 
    {
        buttonSource.Play();
        Application.Quit();
    }

    public void UInable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    public void Pause()
    {
        buttonSource.Play();
        Debug.Log("Game Paused");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ReturnGame()
    {
        buttonSource.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetVolume(float value) 
    {
        buttonSource.Play();
        audioMixer.SetFloat("MainVolume", value);
    
    }

    public void Mute()
    {
        buttonSource.Play();
        player.GetComponent<AudioSource>().enabled = false;

    }

    public void restart()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void home()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void restart2()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void restart3()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1f;
    }
    public void home2()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void Gameplayhome()
    {
        buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    
}
