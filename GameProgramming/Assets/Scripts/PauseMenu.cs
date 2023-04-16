using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;

    public GameObject ControlMenuUI;

    public GameObject InventoryUI;


    public EventSystem eventSystem;

    void Start()
    {
        eventSystem.SetSelectedGameObject(InventoryUI.transform.GetChild(1).gameObject);
    }

    public void OnPause() // this is called to pause the game
    {
        if (GameIsPaused)
        {
            Continue();
        }
        else
        {
            Pause();
        }
    }

    public void Continue() // this is called to continue the game
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        InventoryUI.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;

        eventSystem.SetSelectedGameObject(InventoryUI.transform.GetChild(1).gameObject);
    }

    void Pause() // this is called to pause the game and show the pause menu and disable the player movement
    {
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        InventoryUI.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        

        eventSystem.SetSelectedGameObject(pauseMenuUI.transform.GetChild(1).gameObject);
    }
    public void MainMenuButton() // this is called to go back to the main menu
    {
        Continue();
        DontDestroyOnLoadScene.instance.RemoveDontDestroyOnLoad();
        SceneManager.LoadScene("Main_menu");
    }
    public void OpenSettingMenu() // this is called to open the setting menu
    {
        settingMenuUI.SetActive(true);
        eventSystem.SetSelectedGameObject(settingMenuUI.transform.GetChild(0).gameObject);
    }
    public void CloseSettingMenu() // this is called to close the setting menu
    {
        settingMenuUI.SetActive(false);
        eventSystem.SetSelectedGameObject(pauseMenuUI.transform.GetChild(1).gameObject);
    }


    public void ControlMenu()
    {
        ControlMenuUI.SetActive(true);
        eventSystem.SetSelectedGameObject(ControlMenuUI.transform.GetChild(0).gameObject);
    }
    public void CloseControlMenu()
    {
        ControlMenuUI.SetActive(false);
        eventSystem.SetSelectedGameObject(pauseMenuUI.transform.GetChild(1).gameObject);
    }
}
