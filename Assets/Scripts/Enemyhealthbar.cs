using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealthbar : MonoBehaviour
{




    
    public P1 Enemy;
    public Sprite[] Enemyimage;


    //HealthBar code
 //   public ProjectileScript pro;
 //   public test Enemy;
  //  public Sprite[] Enemyimage;


    public void UpdateEnemy()
    {
        switch (Enemy.Enemyhealth)
        {
            case 3:
                GetComponent<SpriteRenderer>().sprite = Enemyimage[0];
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Enemyimage[1];
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = Enemyimage[2];
                break;
            case 0:
                GetComponent<SpriteRenderer>().sprite = Enemyimage[3];
                break;
        }
    }






}
