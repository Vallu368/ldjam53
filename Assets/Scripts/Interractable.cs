using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    DialogueHandler dialogue;
    public string dialogueText;
    public bool hasItemNeeded;

    private void Awake()
    {
        dialogue = GameObject.Find("DialogueHandler").GetComponent<DialogueHandler>();
    }

    public void Interract()
    {
        if (!dialogue.textIsActive)
        {
            if (dialogueText.Length > 0)
            {
                dialogue.ChangeText(dialogueText);
                dialogue.EnableText();
            }
            else Debug.Log("no dialogue");
        }
        else Debug.Log("already interracting with something");
 
    }
}
