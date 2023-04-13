using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
public GameObject[] objects;
    public static DontDestroyOnLoadScene  instance;
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
            Debug.Log("removing");
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

}

