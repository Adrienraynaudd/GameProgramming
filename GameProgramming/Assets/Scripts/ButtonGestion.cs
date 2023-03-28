
using UnityEngine.SceneManagement;
using UnityEngine;



public class ButtonGestion : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {   

        SceneManager.LoadScene(sceneName);
        
    }

}
