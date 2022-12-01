using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeHungryAttack : MonoBehaviour
{
    public GameObject tongue;
    public Vector3 tonguePos;
    public GameObject differentBanana;
    public GameObject banana;
    public GameObject player;
    public GameObject tongueSegment;
    public bool notStolen = false;
    public List<GameObject> tongueSegments;
    public GameObject newBanana;
    bool captured = false;
    // Start is called before the first frame update
    void Start()
    {
        tonguePos = tongue.transform.position;
        List<GameObject> tongueSegments = new List<GameObject>();
        StartCoroutine(StealBanana());
    }
    
    //coroutine to steal banana from player using tongue
    IEnumerator StealBanana()
    {
        while (true)
        {
            while (notStolen && !captured)
            {
                //tongue move towards player
                tongue.transform.position = Vector3.MoveTowards(tongue.transform.position, banana.transform.position, 0.1f);
                //spawn tongue segments to follow tongue
                tongueSegments.Add(Instantiate(tongueSegment, tongue.transform.position, Quaternion.identity) as GameObject);
                //distance between tongue and banana
                if (Vector3.Distance(tongue.transform.position, banana.transform.position) < 0.5f)
                {
                    newBanana = Instantiate(differentBanana, tongue.transform.position, Quaternion.identity) as GameObject;
                    player.GetComponent<PlayerScript>().Fragments -= 1;
                    player.GetComponent<PlayerScript>().fragmentbar.updateFrag();
                    captured = true;
                }
                yield return new WaitForSeconds(0.01f);
            }
            if (captured && notStolen)
            {
                tongue.transform.position = tonguePos;
                //for each tongue segment in array, destroy last segment starting from last one
                for (int i = tongueSegments.Count - 1; i >= 0; i--)
                {
                    newBanana.transform.position = tongueSegments[i].transform.position;
                    Destroy(tongueSegments[i]);
                    yield return new WaitForSeconds(0.01f);
                }
                notStolen = false;
                captured = false;
                tongueSegments = new List<GameObject>();
                Destroy(newBanana);
                tongueSegment = tongue;
                yield return new WaitForSeconds(0.1f);


            }
            yield return new WaitForSeconds(1);
        }

    }
    //if player collides with this object, destroy banana and tongue
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            notStolen = true;
        }
    }

}
