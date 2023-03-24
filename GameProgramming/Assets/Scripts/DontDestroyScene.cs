
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScene : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyScene  instance;
   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of DontDestroyScene found!");
           return;
       }
       instance = this;

       foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
   }
    public void RemoveDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

}
