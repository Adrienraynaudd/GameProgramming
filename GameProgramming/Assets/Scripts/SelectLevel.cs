using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectLevel : MonoBehaviour
{
  public void LoadLevel(string level)
  {
    SceneManager.LoadScene(level);
  }
}
