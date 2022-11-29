using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeHungry : MonoBehaviour
{
    public PlayerScript player;


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.GetComponent<PlayerScript>();
    
        if (player != null)
        {
            player.Fragments -= 1;
            player.fragmentbar.updateFrag();
            player.transform.position = player.lastPosition;
        }

    }
}
