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
    void Start()
    {
        Inventory.instance.coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        Inventory.instance.UpdateTextUI();
        int currentHealth = PlayerPrefs.GetInt("PlayerHeal", 0);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("CoinCount", Inventory.instance.coinCount);
         PlayerPrefs.SetInt("PlayerHeal", PlayerHealth.instance.currentHealth);
    }
}
