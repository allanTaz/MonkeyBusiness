using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p2health : MonoBehaviour
{


    public P2 Enemy2;
    public Sprite[] Enemyimage2;

    public void UpdateEnemy2()
    {
        switch (Enemy2.Enemyhealth2)
        {
            case 3:
                GetComponent<Image>().sprite = Enemyimage2[0];
                break;
            case 2:
                GetComponent<Image>().sprite = Enemyimage2[1];
                break;
            case 1:
                GetComponent<Image>().sprite = Enemyimage2[2];
                break;
            case 0:
                GetComponent<Image>().sprite = Enemyimage2[3];
                break;
        }
    }

}