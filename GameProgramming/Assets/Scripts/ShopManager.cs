using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopManager : MonoBehaviour
{
    public Animator animator;
    public GameObject shopUI;

    public GameObject ShopWindow;
    public Transform shopPanel;
    public GameObject PanelShop;
    public TextMeshProUGUI namePNJ;
    public static ShopManager instance;
    public EventSystem eventSystem;
    public PlayerInput inputManager;
    public PlayerInput inputManager2;
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
        inputManager.enabled = false;
            inputManager2.enabled = false;
        namePNJ.text = name;
        ItemToSell(items);
        animator.SetBool("isOpen", true);
        Time.timeScale = 0;
        eventSystem.SetSelectedGameObject(ShopWindow.transform.GetChild(1).gameObject);
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
            // cb = button.GetComponent<ButtonItem>();
            // cb.selectedColor = Color.red;
            // button.GetComponent<ButtonItem>().colors = Color.red;
            button.GetComponent<Button>().onClick.AddListener((delegate {button.GetComponent<ButtonItem>().Buy();}));
        }
    }
     public void EndShop() // this is called to close the shop
    {  
            inputManager.enabled = true;
            inputManager2.enabled = true;
        animator.SetBool("isOpen", false);
        Time.timeScale = 1;
    }
}
