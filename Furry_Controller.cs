using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furry_Controller : MonoBehaviour
{
    bool isInvincible;
    float invincibleTimer;
    public float incvincibleTime = 2.0f;
    Vector2 position;
    Rigidbody2D rigidbody2d;
    public int maxHealth = 5;
    public int Health { get { return currentHealth; } }
    int currentHealth;
    public float speed;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = incvincibleTime;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    
}
