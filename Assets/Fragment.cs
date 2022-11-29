using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    public PlayerScript player;

    float Timer = 0.0f;
    bool exist = false;

    public float Existtime = 1.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.GetComponent<PlayerScript>();

        if(player != null)
        {
     //       player.ChangeFragment(1);
            Destroy(gameObject);
            transform.GetComponent<Animation>().Play("Nice");
      //      Fragment += 1;
      //      FragmentNum.text = Fragment.ToString();

        }

    
    }

  

    void update() 
    {
      if (exist)
        {
            Timer += Time.deltaTime;
        }
            
        
        if (Timer > Existtime)
        {
            Debug.Log("aaa=");
            
            Timer = 0.0f;
            
        }
    }
}
