using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        string startLevel = PlayerPrefs.GetString("startLevel"); // this is called to load the level that the player was on
        SceneManager.LoadScene(startLevel); // this is called to load the level that the player was on
    }
}
