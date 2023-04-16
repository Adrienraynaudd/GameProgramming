using UnityEngine;

public class LoadAndSaveScene : MonoBehaviour
{
     public static LoadAndSaveScene instance;

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of LoadAndSaveScene found!");
           return;
       }
       instance = this;
   }
    void Start() // this is called to load the data from the last time the player played the game
    {
        Inventory.instance.coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        Inventory.instance.UpdateCoinUI();
        int CurrentHealth = PlayerPrefs.GetInt("PlayerHeal",PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth =CurrentHealth;
        PlayerHealth.instance.healthBar.SetHealth(CurrentHealth);
    }
    public void SaveData() // this is called to save the data of the player
    {
        PlayerPrefs.SetInt("CoinCount", Inventory.instance.coinCount);
        PlayerPrefs.SetInt("PlayerHeal", PlayerHealth.instance.currentHealth);
    }
}
