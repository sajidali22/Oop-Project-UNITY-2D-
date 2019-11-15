using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Furry_Controller : MonoBehaviour
{
    public Animator animator;

    public bool movement = true;

    bool facingRight = true;
    private float movementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    bool grounded;
    public float jumpForce = 400f;
    public float airAccelaration;
    bool colliding;

    bool isInvincible;
    float invincibleTimer;
    public float incvincibleTime = 2.0f;

    Vector2 position;
    Rigidbody2D rigidbody2d;

    public int maxHealth = 5;
    public int Health { get { return currentHealth; } }
    int currentHealth;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public float speed;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {       
        grounded = false;
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        if(grounded == false)
        {
            animator.SetBool("IsJumping", false);
        }
        
    }


    void Update()
    {
        if (movement)
        {
            float horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            position = rigidbody2d.position;
            Vector3 targetVelocity = new Vector2(horizontal * 10f, rigidbody2d.velocity.y);
            // And then smoothing it out and applying it to the character
            rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

            if (Input.GetButtonDown("Jump") && grounded)
            {
                Jump();
                animator.SetBool("IsJumping", true);
            }

            if (horizontal > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (horizontal < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }

            if (isInvincible)
            {
                invincibleTimer -= Time.deltaTime;
                if (invincibleTimer < 0)
                {
                    isInvincible = false;
                }
            }
        }
    }

   /* public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            else
            {
                isInvincible = true;
                invincibleTimer = incvincibleTime;
            }
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
                 
        }
        
    }*/
    
    void Jump()
    {
        // Calculate the velocity required to achieve the target jump height.
        rigidbody2d.AddForce(new Vector2(0f, jumpForce) );
        grounded = false;
        speed = airAccelaration;
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
