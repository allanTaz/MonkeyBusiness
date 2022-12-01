using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class P3 : MonoBehaviour
{

    public float Enemyhealth3 = 3, maxEnemyhealth3 = 3;
    public p3health enemyhealthbar3;
    public Animator anim3;




    // [SerializeField] private Rigidbody2D rb;


    private bool IsDeath3;


    void start()
    {
        Enemyhealth3 = 3;
        enemyhealthbar3.transform.parent = gameObject.transform;

    }



    void update()
    {
      //  if (Enemyhealth3 == 0)
      //  {
      //      anim.SetBool("IsHunDie", true);
      //      Invoke("broke", 2f);
      //  }






    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pro")
        {

            Enemyhealth3 -= 1;
            enemyhealthbar3.UpdateEnemy3();
            IsDeath3 = true;

        }



    }


    void broke()
    {

        Destroy(gameObject);

    }

}
