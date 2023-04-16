using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


public class ButtonItem : MonoBehaviour // this is called for the button of the shop and if the player have enough coins then the player will buy the item
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
            Inventory.instance.items.Add(item);
            Inventory.instance.UpdateUI();
            Inventory.instance.UpdateCoinUI();
        }
    }
}
