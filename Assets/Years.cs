using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Years : MonoBehaviour
{
    public GameObject nextpage;
    public void nexthome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void nextmute()
    {
        nextpage.GetComponent<AudioSource>().enabled = false;
    }
}
