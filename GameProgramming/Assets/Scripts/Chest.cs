using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    private Text interactUI;
    private bool isInRange;

    public Animator animator;
    public int coinsToGive;
    public AudioClip openChestSound;


    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>(); // this is called to show the text "press E to interact"
    }


    public void OnInteract() // this is called to open the chest
    {
        OpenChest();
    }
    void OpenChest() // this is called to give the player the coins after the player open the chest
    {
        AudioSource.PlayClipAtPoint(openChestSound, transform.position);
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoin(coinsToGive);
        CurrentSceneManager.instance.CoinsPickedUp += coinsToGive;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) // this is called to check if the player enter in the chest detection area and if it is true then the text "press E to interact" will appear
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // this is called to check if the player exit from the chest detection area and if it is true then the text "press E to interact" will disappear
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
        }
    }
}
