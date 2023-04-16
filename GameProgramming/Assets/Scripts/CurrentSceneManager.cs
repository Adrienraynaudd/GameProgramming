using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int CoinsPickedUp; // this is called to count the coins that the player picked up in the level and it will be used in the shop
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
