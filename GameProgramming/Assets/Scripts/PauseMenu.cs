using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;

    public GameObject ControlMenuUI;


    public EventSystem eventSystem;


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
        

        eventSystem.SetSelectedGameObject(pauseMenuUI.transform.GetChild(1).gameObject);
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
        eventSystem.SetSelectedGameObject(settingMenuUI.transform.GetChild(0).gameObject);
    }
    public void CloseSettingMenu()
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
