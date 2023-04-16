using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverManager : MonoBehaviour
{

    public EventSystem eventSystem;

    public GameObject InventoryUI;
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
        InventoryUI.SetActive(false);
        eventSystem.SetSelectedGameObject(gameOverUI.transform.GetChild(1).gameObject);
    }
    public void RestartButton()
    {
        Inventory.instance.RemoveCoin(CurrentSceneManager.instance.CoinsPickedUp);
        CurrentSceneManager.instance.CoinsPickedUp = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.respawnPlayer();
        gameOverUI.SetActive(false);
        InventoryUI.SetActive(true);
        eventSystem.SetSelectedGameObject(InventoryUI.transform.GetChild(1).gameObject);
    }
    public void MenuButton()
    {
        DontDestroyOnLoadScene.instance.RemoveDontDestroyOnLoad();
        SceneManager.LoadScene("Main_menu");
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
