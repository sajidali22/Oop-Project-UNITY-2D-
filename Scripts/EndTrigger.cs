using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gamemanager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamemanager.CompleteLevel();
    }
}
