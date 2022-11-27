using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //HealthBar code
    public PlayerScript player;
    public Sprite[] healthBarImage;
    
    public void UpdateHealthBar()
    {
        switch (player.health)
        {
            case 3:
                GetComponent<Image>().sprite = healthBarImage[0];
                break;
            case 2:
                GetComponent<Image>().sprite = healthBarImage[1];
                break;
            case 1:
                GetComponent<Image>().sprite = healthBarImage[2];
                break;
            case 0:
                GetComponent<Image>().sprite = healthBarImage[3];
                break;
        }
    }
}
