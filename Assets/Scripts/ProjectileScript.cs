using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private int num;
    

    

    //Destroy object on collision
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        //P1 Hungry = collision.GetComponent<P1>();
        
        if (!(collision.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
        }
     //   if (collision.gameObject.tag != "Le Hungry" && collision.gameObject.tag != "Player")
     //   {
      //      Destroy(gameObject);

     //   }

       


    }



}
