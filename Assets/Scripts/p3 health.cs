using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p3health : MonoBehaviour
{


    public P3 Enemy3;
    public Sprite[] Enemyimage3;

    public void UpdateEnemy3()
    {
        switch (Enemy3.Enemyhealth3)
        {
            case 3:
                GetComponent<Image>().sprite = Enemyimage3[0];
                break;
            case 2:
                GetComponent<Image>().sprite = Enemyimage3[1];
                break;
            case 1:
                GetComponent<Image>().sprite = Enemyimage3[2];
                break;
            case 0:
                GetComponent<Image>().sprite = Enemyimage3[3];
                break;
        }
    }

}