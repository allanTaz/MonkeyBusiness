using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    //set public gameobject for the bullet
    public GameObject bullet;
    public float health = 3, maxHealth = 3;
    public HealthBar healthBar;
    private float horizontal;
    public Vector3 lastPosition;


    public AudioSource jumpSource;
    public AudioSource hurtSource;
    public AudioSource bananaSource;
    public AudioSource throwSource, throwSource2;
    public int Fragments;
    public FragmentBar fragmentbar;
    public Text FragmentsNum;
    public Text Tim;

    public bool IsHurt;
    private bool IsFinish;

    //speed
    public float speed = 8f;
    //jumping power
    public float jumpPower = 16f;
    private bool isFacingRight = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    float interval = 3f;
    float next = 0f;
    public Animator animator;
    bool jumping = false;
    public float onLandTime;
    bool firing = false;
    public RigidbodyConstraints2D currentType;

    void Start()
    {
        currentType = rb.constraints;
        lastPosition = transform.position;
    }

    // Start is called before the first frame update
    void Update()
    {

        if (isGrounded())
        {
            sw.Start();
            onLandTime = sw.ElapsedMilliseconds;
            if (sw.ElapsedMilliseconds > 60f)
            {
                animator.SetBool("IsJumping", false);
                jumping = false;
                sw.Reset();
            }
            if (Time.time >= next)
            {
                lastPosition = transform.position;
                next += interval;
            }
        }
        if (transform.position.y < -7 || transform.position.y > 6)
        {
            health -= 1;
            healthBar.UpdateHealthBar();
            hurtSource.Play();
            transform.position = lastPosition;
            
        }
        //Life die and play again

        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Time.timeScale = 0f;
        }


        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            animator.SetBool("IsJumping", true);
            jumping = true;
            
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            animator.SetBool("IsJumping", true);
            jumping = true;
            jumpSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (IsHurt)
        {
            animator.SetBool("IsGettinghit", true);
            
            if (Mathf.Abs(rb.velocity.x)<0.1f)
            {
                animator.SetBool("IsGettinghit", false);
                IsHurt = false;
            }

          
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsAttacking", true);
            throwSource2.Play();
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
        if (Input.GetButtonDown("Fire2") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            animator.SetBool("IsThrowing", true);
            throwSource.Play();
            StartCoroutine(Shoot());
        }
        else
        {
            animator.SetBool("IsThrowing", false);
        }
        
        Flip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsHurt) 
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        
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

    IEnumerator Shoot()
    {
        firing = true;
        yield return new WaitForSeconds(0.25f);

        if (isFacingRight)
        {
            GameObject bulletClone = Instantiate(bullet, transform.position + new Vector3(1, 0, 0), transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        }
        else
        {
            GameObject bulletClone = Instantiate(bullet, transform.position + new Vector3(-1, 0, 0), transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
        }
        firing = false;
    }



    //     }
    public void OnTriggerEnter2D(Collider2D other)
   {
       // PlayerScript player = other.GetComponent<PlayerScript>();

        if (other.gameObject.tag == "Fragment")
        {
            
            
            Destroy(other.gameObject);
            Fragments += 1;           
            fragmentbar.updateFrag();
            bananaSource.Play();
           // FragmentsNum.text = Fragments.ToString();
            //   FragmentsNum.text = Fragments.ToString();
            if (Fragments >= 5)
            {
                health += 1;
                healthBar.UpdateHealthBar();
            }

            //  Debug.Log(Fragments);
        }


        if (other.gameObject.tag == "FinalFrag")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Time.timeScale = 0f;
        }
        // else if (Fragments >= 5)
        //     {
        //         health += 1;
        //         healthBar.UpdateHealthBar();
        //    }




    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Le Mad" )
        {
            if (animator.GetBool("IsJumping")) 
            {
                Destroy(other.gameObject);
                animator.SetBool("IsJumping", true);

                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                
            }else if(transform.position.x < other.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                health -= 1;
                healthBar.UpdateHealthBar();
                hurtSource.Play();
                IsHurt = true; 
            }
               
        }

        if(other.gameObject.tag == "JumpPlant")
        {
            if (animator.GetBool("IsJumping"))
            {
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            }
            else if (transform.position.y > other.gameObject.transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x,16f);
                IsHurt = true;
                

            }
        }




    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beam")
        {
            animator.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beam")
        {
            animator.enabled = true;
            rb.constraints = currentType;
            health -= 1;
            healthBar.UpdateHealthBar();
        }
    }


    //public void UpdateTime()
    //{

    //   gametime += Time.deltaTime;
    //   Debug.Log((int)gametime);


    //    UIManager.instance.UpdateTimeBar((int)gametime);

    //µ¹¼ÆÊ±
    //UpdateTimeBar((int)(maxtime-gametime));
    // }



}
