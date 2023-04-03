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
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }
    void OpenChest()
    {
        AudioSource.PlayClipAtPoint(openChestSound, transform.position);
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoin(coinsToGive);
        GetComponent<BoxCollider2D>().enabled = false;
        isInRange = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
