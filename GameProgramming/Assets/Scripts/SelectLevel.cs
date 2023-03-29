using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
  public void LoadLevel(string level)
  {
    SceneManager.LoadScene(level);
  }
}
