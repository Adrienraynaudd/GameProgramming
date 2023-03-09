using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Awake()
    { 
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PauseMenuUtility");

        for (int i = 0; i < objs.Length; i++)
        {
            DontDestroyOnLoad(objs[i]);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        // PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // public void LoadMenu()
    // {
    //     DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
    //     SceneManager.LoadScene("MainMenu");
    // }
}
