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
        SceneManager.LoadScene("Main_menu");
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
