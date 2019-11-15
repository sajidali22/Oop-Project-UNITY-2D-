using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Controller : MonoBehaviour
{
    Rigidbody2D rB;
    int direction = 1;
    float Timer;
    bool donotMove = false;
    public float changeTimer;
    public float speed;
    public Rigidbody2D player;

    public float distance;

    public Animator animator;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        Timer = changeTimer;
        
    }

    void Update()
    {
        Vector2 position = rB.position;
        Timer -= Time.deltaTime;
        if (Vector3.Distance(rB.transform.position, player.transform.position) < distance)
        {
            donotMove = false;
            if (rB.transform.position.x > player.transform.position.x)
            {
                animator.SetBool("Attack", true);

               
            }
            else
            {
                animator.SetBool("AttackRight", true);
               
            }
        }
        else
        {
            donotMove = true;
            animator.SetBool("Attack", false);
            animator.SetBool("AttackRight", false);
        }

        
        if (donotMove)
        {
            if (Timer < 0)
            {
                direction = -direction;
                Timer = changeTimer;
            }

            if (direction > 0)
            {
                position.x = position.x + Time.deltaTime * speed;
                animator.SetBool("D_facingRight", true);

            }
            else
            {

                position.x = position.x + Time.deltaTime * speed * -1;
                animator.SetBool("D_facingRight", false);

            }
            rB.MovePosition(position);
        }
        
    }
        
    
     void OnCollisionEnter2D(Collision2D other)
    {
        Furry_Controller cont = other.gameObject.GetComponent<Furry_Controller>();
        if(cont!= null)
        {
            
        }
        
    }
  
}
