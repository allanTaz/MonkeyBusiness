using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //set public gameobject for the bullet
    public GameObject bullet;
    public float health = 3, maxHealth = 3;
    public HealthBar healthBar;
    private float horizontal;
    private Vector3 lastPosition;
    //speed
    public float speed = 8f;
    //jumping power
    public float jumpPower = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    float interval = 3f;
    float next = 0f;

    void Start()
    {
        lastPosition = transform.position;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (isGrounded())
        {
            if (Time.time >= next)
            {
                Debug.Log("Saved");

                lastPosition = transform.position;
                next += interval;
            }
        }
        if (transform.position.y < -7 || transform.position.y > 6)
        {
            health -=1; 
            healthBar.UpdateHealthBar();
            transform.position = lastPosition;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump")&& isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    
    private void Flip()
    {
        {
            if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }

}
