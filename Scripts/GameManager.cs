using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float RestartDelay;
    public GameObject Complete_levelUI;
    public GameObject Game_OverUI;

    public void EndGame()
    {
        Debug.Log("End Game");
        Game_OverUI.SetActive(true);
    }
   
    public void CompleteLevel()
    {
        Complete_levelUI.SetActive(true);
        
    }
    public void GameOver()
    {

    }





}
