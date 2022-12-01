using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Mainmenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
 
    public GameObject player;



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
        Time.timeScale = 0f;
    }
    public void ReturnGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetVolume(float value) 
    {
        audioMixer.SetFloat("MainVolume", value);
    
    }

    public void Mute()
    {
        player.GetComponent<AudioSource>().enabled = false;

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void restart2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void restart3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void home2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void Gameplayhome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    
}
