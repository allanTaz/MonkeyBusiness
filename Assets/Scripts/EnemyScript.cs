using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    float timer = 0;
    private float speed = 5f;
    public Transform groundCheck;
    [SerializeField] private Rigidbody2D rb;
    public GameObject bullet;
    private bool patrol;
    public bool mustTurn;
    // Start is called before the first frame update
    void Start()
    {
        patrol = true;
        
    }
    void FixedUpdate()
    {
        if (patrol)
        {
            mustTurn = !Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        }
    }
    void Update()
    {
        if ((Vector2.Distance(transform.position, player.transform.position) < 5f) && 
            ((transform.position.x-player.transform.position.x>0) && (transform.localScale.x<0) ||
            (transform.position.x - player.transform.position.x < 0) && (transform.localScale.x > 0)))
        {
            patrol = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
            timer += Time.deltaTime;
            if (timer > 1)
            {
                Attack();
                timer = 0;
            }
        }
        if (patrol)
            Patrol();
    }
    void Patrol()
    {
        if (mustTurn) {
            Flip();
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void Flip()
    {
        patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        patrol = true;
    }
    void Attack()
    {
        Vector2 bulletPosition = transform.position;
        if (transform.localScale.x < 0)
        {
            bulletPosition = new Vector2(transform.position.x - 2, transform.position.y);
            var projectile = Instantiate(bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 90))) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0);
        }
        else
        {
            bulletPosition = new Vector2(transform.position.x + 2, transform.position.y);
            var projectile = Instantiate(bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 90))) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0);
        }
        //Launch the projectile


    }

}
//Vector3 bulletPosition = transform.position;
//Vector2 direction = new Vector3(1, 0, 0);
//rb.velocity = new Vector2(0, rb.velocity.y);
//if (player.transform.position.x - transform.position.x > 0)
//{
//    transform.localScale = new Vector3(1, 1, 1);
//    bulletPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
//    direction = new Vector3(1, 0, 0);
//    isFacingRight = true;
//}
//else
//{
//    transform.localScale = new Vector3(-1, 1, 1);
//    bulletPosition = new Vector3(transform.position.x -1, transform.position.y, transform.position.z);
//    direction = new Vector3(-1, 0, 0);
//    isFacingRight = false;
//}

////shoot bullet
//var projectile = Instantiate(bullet, bulletPosition, Quaternion.identity) as GameObject;

//projectile.GetComponent<Rigidbody2D>().AddForce(direction * 10, ForceMode2D.Impulse);
//yield return new WaitForSeconds(1);