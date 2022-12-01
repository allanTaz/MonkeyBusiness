using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Years : MonoBehaviour
{
    public GameObject nextpage;
    public AudioSource buttonSource;
    public void nexthome()
    {buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }
    public void next()
    {buttonSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void nextmute()
    {buttonSource.Play();
        nextpage.GetComponent<AudioSource>().enabled = false;
        
    }
}
