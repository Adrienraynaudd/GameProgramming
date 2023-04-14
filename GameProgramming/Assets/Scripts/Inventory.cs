using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using TMPro;

public class Inventory : MonoBehaviour
{
   public int coinCount;
   public Text coinText;
   public List<item> items = new List<item>();
   private int index = 0 ;
   public Image itemImage;
    public TextMeshProUGUI NameItem;
   public Sprite defaultImage;
   public static Inventory instance;
   public PlayerEffect playerEffect;

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of Inventory found!");
           return;
       }
       instance = this;
   }
    private void Start()
    {
         UpdateUI();
    }
   public void ConsumedItem(){
    if (items.Count == 0)
    {
        return;
    }
    item item = items[index];
    PlayerHealth.instance.HealPlayer(item.hp);
    playerEffect.AddSpeed(item.speed, item.duration);
    items.Remove(item);
    GetNextItem();
    UpdateUI();

   }
   public void GetNextItem()
   {
         if (items.Count == 0)
         {
              return;
         }
       index++;
       if (index >= items.Count)
       {
           index = 0;
       }
         UpdateUI();
   }
   public void GetPreviousItem()
   {
        if (items.Count == 0)
        {
            return;
        }
       index--;
         if (index < 0)
         {
              index = items.Count - 1;
         }
         UpdateUI();
   }
   public void UpdateUI()
   {
        if (items.Count > 0)
        {
            itemImage.sprite = items[index].icon;
            NameItem.text = items[index].names;
        }
        else
        {
            itemImage.sprite = defaultImage;
            NameItem.text = "No Item";
        }
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
