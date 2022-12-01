using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leshyattack : MonoBehaviour
{
    //game object
    public GameObject beam;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateBeam());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //coroutine activate beam with interval
    IEnumerator ActivateBeam()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.765f);
            beam.SetActive(true);
            yield return new WaitForSeconds(1.76f);
            beam.SetActive(false);
        }
    }

}
