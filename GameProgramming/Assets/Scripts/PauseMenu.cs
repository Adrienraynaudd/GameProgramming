using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
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
        DontDestroyScene.instance.RemoveDontDestroyOnLoad();
        Continue();
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
