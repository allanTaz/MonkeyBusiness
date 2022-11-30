using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{

    private int num;

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "pro")
        {
            num += 1;
            if(num==3)
            {
                Destroy(gameObject);
            }
            
        }

    }

}