using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectLevel : MonoBehaviour
{
  public void LoadLevel(string level)
  {
    PlayerPrefs.SetString("startLevel", level);
    SceneManager.LoadScene("PreLoad");

  }
}
