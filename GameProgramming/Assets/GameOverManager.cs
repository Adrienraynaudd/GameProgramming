
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
     public static GameOverManager instance;

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of GameOverManager found!");
           return;
       }
       instance = this;
   }
    public GameObject gameOverUI;
   
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }
}
