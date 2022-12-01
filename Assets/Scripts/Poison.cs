using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour

{
    public PlayerScript player;
   // public HeathBar heathBar;
 
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.GetComponent<PlayerScript>();
       // HeathBar heathBar
        if (player != null)
        {
            player.health -= 1;
            player.healthBar.UpdateHealthBar();
            player.transform.position = player.lastPosition;
          //  player.animator.SetBool("IsJumping", true);
          //  player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpPower);
        }

    }
}
