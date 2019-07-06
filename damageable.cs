using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageable : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)            
    {
        Furry_Controller controller = other.GetComponent<Furry_Controller>();
        if(controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
    
}
