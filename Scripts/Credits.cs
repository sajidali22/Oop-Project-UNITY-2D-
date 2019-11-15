using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    

    public void Quit1()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Menu2()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu");
    }
    public void Restart1()
    {
        
        SceneManager.LoadScene("Level 01");
    }
}
