using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public int coinCount;
   public Text coinText;
   public static Inventory instance;

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of Inventory found!");
           return;
       }
       instance = this;
   }

   public void AddCoin(int count)
   {
       coinCount += count;
       UpdateTextUI();
   }
   public void RemoveCoin(int count)
   {
       coinCount -= count;
        UpdateTextUI();
   }

   public void UpdateTextUI()
    {
         coinText.text = coinCount.ToString();
    }
}
