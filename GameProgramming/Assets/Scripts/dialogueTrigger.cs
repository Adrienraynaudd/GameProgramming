
using UnityEngine;
using UnityEngine.UI;

public class dialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isTriggered ;
    private Text interactUI;
    // Update is called once per frame
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
  
    public void OnInteract() // this is called to open the dialogue
    {
        TriggerDialogue();
    }


    void OnTriggerEnter2D(Collider2D other) // this is called to check if the player enter in the dialogue detection area and if it is true then the text "press E to interact" will appear
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            
            interactUI.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) // this is called to check if the player exit from the dialogue detection area and if it is true then the text "press E to interact" will disappear
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            
            interactUI.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }
     void TriggerDialogue() // this is called to open the dialogue
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
