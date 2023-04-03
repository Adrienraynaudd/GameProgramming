using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        string startLevel = PlayerPrefs.GetString("startLevel");
        SceneManager.LoadScene(startLevel);
    }
}
