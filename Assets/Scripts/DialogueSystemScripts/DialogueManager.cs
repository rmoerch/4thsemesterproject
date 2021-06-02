using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
   
    public Animator animator;
    private Queue<string> sentenceQueue;
    private List<string> sentenceList;

    void Start()
    {
        sentenceQueue = new Queue<string>();
        sentenceList = new List<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentenceQueue.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentenceQueue.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void StartRandomDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentenceList.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentenceList.Add(sentence);
        }

        DisplayRandomSentence();
    }

    public void DisplayRandomSentence()
    {

        //If there are no sentences -> end the dialogue!
        if (sentenceList.Count == 0)
        {
            EndDialogue();
            return;
        }

        var sentence = Random.Range(0, sentenceList.Count);
        dialogueText.text = sentenceList[sentence];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceList[sentence]));

    }


    public void DisplayNextSentence()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentenceQueue.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Show each letter of each word in the sentence - one by one.
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }


    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
