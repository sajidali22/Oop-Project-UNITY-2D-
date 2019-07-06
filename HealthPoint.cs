using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Furry_Controller controller = other.GetComponent<Furry_Controller>();

        if (controller != null)
        {
            if (controller.Health <= controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }



}
