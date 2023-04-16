using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;

    public EventSystem eventSystem;

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
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause() // this is called to pause the game and show the pause menu and disable the player movement
    {
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
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
    }
    public void CloseSettingMenu() // this is called to close the setting menu
    {
        settingMenuUI.SetActive(false);
    }
}
