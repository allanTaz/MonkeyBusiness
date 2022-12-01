using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class P1 : MonoBehaviour
{

    public float Enemyhealth = 3, maxEnemyhealth = 3;
    public Enemyhealthbar enemyhealthbar;
    private Animator anim;




    // [SerializeField] private Rigidbody2D rb;


    private bool IsDeath;


    void start()
    {
        Enemyhealth = 3;
        enemyhealthbar.transform.parent = gameObject.transform;
        anim = GetComponent<Animator>();
    }



    void update()
    {

    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pro")
        {

            Enemyhealth -= 1;
            enemyhealthbar.UpdateEnemy();
            if (Enemyhealth == 0)
            {
                //     anim.SetBool("IsHunDie",true);
                Destroy(gameObject);

            }


        }


        void death()
        {
            Destroy(gameObject);

        }



    }
}
