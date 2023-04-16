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

       foreach (var element in objects) // this is called to add the objects in the scene to the DontDestroyOnLoadScene
        {
            DontDestroyOnLoad(element);
        }
   }
    public void RemoveDontDestroyOnLoad() // this is called to remove the objects from the DontDestroyOnLoadScene
    {
        foreach (var element in objects)
        {
            Debug.Log("removing");
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

}

