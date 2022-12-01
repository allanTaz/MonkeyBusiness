using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class P2 : MonoBehaviour
{

    public float Enemyhealth2 = 3, maxEnemyhealth2 = 3;
    public p2health enemyhealthbar2;
    public Animator anim2;




    // [SerializeField] private Rigidbody2D rb;


    private bool IsDeath2;


    void start()
    {
        Enemyhealth2 = 3;
        enemyhealthbar2.transform.parent = gameObject.transform;

    }



    void update()
    {
        //   if (Enemyhealth2 == 0)
        //  {
        //       anim.SetBool("IsHunDie", true);
        //       Invoke("broke", 2f);
        //    }






    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pro")
        {

            Enemyhealth2 -= 1;
            enemyhealthbar2.UpdateEnemy2();
            IsDeath2 = true;

        }



    }


    void broke()
    {

        Destroy(gameObject);

    }

}
