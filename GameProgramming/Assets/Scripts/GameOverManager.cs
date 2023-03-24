using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(CurrentSceneManager.instance.isPlayerPresent)
        {
            DontDestroyScene.instance.RemoveDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }
    public void RestartButton()
    {
        Inventory.instance.RemoveCoin(CurrentSceneManager.instance.CoinsPickedUp);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.respawnPlayer();
        gameOverUI.SetActive(false);
    }
    public void MenuButton()
    {
        //menu du jeu
    }
    public void quitButton()
    {
        //quitter le jeu
        Application.Quit();
    }
}
