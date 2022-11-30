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



}
