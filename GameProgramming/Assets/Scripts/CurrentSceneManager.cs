using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int CoinsPickedUp;
     public static CurrentSceneManager  instance;
   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of CurrentSceneManager found!");
           return;
       }
       instance = this;
   }
}
