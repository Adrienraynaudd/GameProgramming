using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public Animator animator;
    public GameObject shopUI;
    public Transform shopPanel;
    public TextMeshProUGUI namePNJ;
    public static ShopManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ShopManager found!");
            return;
        }
        instance = this;
    }
    public void Shop(item[] items, string name) // this is called to open the shop and show the items that the player can buy
    {
        namePNJ.text = name;
        ItemToSell(items);
        animator.SetBool("isOpen", true);
    }
    void ItemToSell(item[] items){ // this is called to instantiate the items in the shop
        foreach (Transform child in shopPanel.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(shopUI, shopPanel);
            button.GetComponent<ButtonItem>().nameItem.text = items[i].names;
            button.GetComponent<ButtonItem>().iconItem.sprite = items[i].icon;
            button.GetComponent<ButtonItem>().priceItem.text = items[i].price.ToString();
            button.GetComponent<ButtonItem>().item = items[i];
            button.GetComponent<Button>().onClick.AddListener((delegate {button.GetComponent<ButtonItem>().Buy();}));
        }
    }
     public void EndShop() // this is called to close the shop
    {
        animator.SetBool("isOpen", false);
    }
}
