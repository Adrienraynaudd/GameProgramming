using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;


    void Update()
    {
        
    }

    public void OnPause()
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

    public void Continue()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void MainMenuButton()
    {
        Continue();
        DontDestroyOnLoadScene.instance.RemoveDontDestroyOnLoad();
        SceneManager.LoadScene("Main_menu");
    }
    public void OpenSettingMenu()
    {
        settingMenuUI.SetActive(true);
    }
    public void CloseSettingMenu()
    {
        settingMenuUI.SetActive(false);
    }
}
