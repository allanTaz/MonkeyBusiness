using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeHungryAttack : MonoBehaviour
{
    public GameObject tongue;
    public GameObject banana;
    public GameObject player;
    public GameObject tongueSegment;
    public bool notStolen = false;
    GameObject[] tongueSegments;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StealBanana());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - player.transform.position.x< 7)
        {
            notStolen = true;
        }
    }
    //coroutine to steal banana from player using tongue
    IEnumerator StealBanana()
    {
        yield return new WaitForSeconds(2f);
    }
}
