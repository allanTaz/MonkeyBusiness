using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mad : MonoBehaviour
{
    public PlayerScript player;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.GetComponent<PlayerScript>();
        // HeathBar heathBar
        if (player != null)
        {
            player.health -= 1;
            player.healthBar.UpdateHealthBar();
            player.transform.position = player.lastPosition;
        }

    }
}
