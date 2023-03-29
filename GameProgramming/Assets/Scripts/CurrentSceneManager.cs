using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int CoinsPickedUp;
     public static CurrentSceneManager  instance;
     public Vector3 PlayerRespawnPosition;
   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of CurrentSceneManager found!");
           return;
       }
       instance = this;

       PlayerRespawnPosition = GameObject.Find("Player").transform.position;
   }
}
