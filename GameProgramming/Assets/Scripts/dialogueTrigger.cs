
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
  
    public void OnInteract()
    {
        TriggerDialogue();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            
            interactUI.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            
            interactUI.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }
     void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
