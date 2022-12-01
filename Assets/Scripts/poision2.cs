using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poision2 : MonoBehaviour
{

    private int num;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pro")
        {
            num += 1;
            if (num == 3)
            {
                Destroy(gameObject);
            }
        }





    }
}
