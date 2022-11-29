using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentBar : MonoBehaviour
{
    public PlayerScript player;
    public Sprite[] image;

    public void updateFrag() 
    {
        switch (player.Fragments) 
        {
            case 10:
                GetComponent<Image>().sprite = image[10];
                break;
            case 9:
                GetComponent<Image>().sprite = image[9];
                break;
            case 8:
                GetComponent<Image>().sprite = image[8];
                break;
            case 7:
                GetComponent<Image>().sprite = image[7];
                break;
            case 6:
                GetComponent<Image>().sprite = image[6];
                break;
            case 5:
                GetComponent<Image>().sprite = image[5];
                break;
            case 4:
                GetComponent<Image>().sprite = image[4];
                break;
            case 3:
                GetComponent<Image>().sprite = image[3];
                break;
            case 2:
                GetComponent<Image>().sprite = image[2];
                break;
            case 1:
                GetComponent<Image>().sprite = image[1];
                break;
            case 0:
                GetComponent<Image>().sprite = image[0];
                break;

        }
        
    }
}
