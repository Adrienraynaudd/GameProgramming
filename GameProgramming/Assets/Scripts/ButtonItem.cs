using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


public class ButtonItem : MonoBehaviour
{
    public TextMeshProUGUI nameItem;
    public Image iconItem;
    public TextMeshProUGUI priceItem;

    public item item;

    public void Buy()
    {
        if(Inventory.instance.coinCount >= item.price)
        {
            Inventory.instance.coinCount -= item.price;
            CurrentSceneManager.instance.CoinsPickedUp -= item.price;
            Inventory.instance.items.Add(item);
            Inventory.instance.UpdateUI();
            Inventory.instance.UpdateCoinUI();
        }
    }
}
