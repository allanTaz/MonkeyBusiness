using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Globalmusic : MonoBehaviour
{
    public GameObject UImusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
