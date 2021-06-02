using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
            {
                TriggerRandomDialogue();
            }
            else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                TriggerDialogue();
            }
            
        }
    }

    private void TriggerRandomDialogue()
    {
        FindObjectOfType<DialogueManager>().StartRandomDialogue(dialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }    
}
