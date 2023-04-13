using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

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
    public void StartDialogue(Dialogue dialogue)
    {
        button.Select();
        animator.SetBool("isOpen", true);
        namePNJ.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
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
    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
