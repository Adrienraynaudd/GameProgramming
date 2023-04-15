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
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract()
    {
        OpenChest();
    }
    void OpenChest()
    {
        AudioSource.PlayClipAtPoint(openChestSound, transform.position);
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoin(coinsToGive);
        CurrentSceneManager.instance.CoinsPickedUp += coinsToGive;
        GetComponent<BoxCollider2D>().enabled = false;
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
