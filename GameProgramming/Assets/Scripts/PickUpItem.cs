using UnityEngine;
using UnityEngine.UI;
public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    private Text interactUI;

    public item item;
    public AudioClip itemSound;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    public void OnInteract()
    {
        TakeItem();
    }
    void TakeItem() // this is called to add the item to the inventory and then destroy the item
    {
      Inventory.instance.items.Add(item);
        Inventory.instance.UpdateUI();
      AudioManager.instance.PlayClipAt(itemSound, transform.position);
      interactUI.enabled = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
        }
    }
}
