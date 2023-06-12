using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Button button;
    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI namePNJ;
    private Queue<string> sentences;
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager found!");
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue) // this is called to start the dialogue
    {
        button.Select();
        animator.SetBool("isOpen", true);
        namePNJ.text = dialogue.name;
        
        sentences.Clear(); // this is called to clear the sentences
        foreach (string sentence in dialogue.sentences) // this is called to add the sentences in the queue
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() // this is called to display the next sentence
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence) // this is called to read the sentence letter by letter
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void EndDialogue() // this is called to end the dialogue
    {
        animator.SetBool("isOpen", false);
    }
}
