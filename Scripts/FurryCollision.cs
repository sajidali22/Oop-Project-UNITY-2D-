using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FurryCollision : MonoBehaviour
{
    public Furry_Controller furry;
    


    void OnCollisionEnter2D(Collision2D other)
    {
        enemy_Controller cont = other.gameObject.GetComponent<enemy_Controller>();
        Enmy_Controllerbasic basic = other.gameObject.GetComponent<Enmy_Controllerbasic>();
        if (cont != null)
        {
            furry.movement = false;
            FindObjectOfType<GameManager>().EndGame();           
        }
        else if(basic != null)
        {
            furry.movement = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (other.gameObject.tag == "spike"){
            furry.movement = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
   
}   
