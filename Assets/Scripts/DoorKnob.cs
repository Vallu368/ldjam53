using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnob : MonoBehaviour
{
    DialogueHandler dialogue;
    InventoryHandler inventory;
    public string dialogueText;
    public GameObject doorClosedBg;
    public GameObject doorOpenBg;

    private void Awake()
    {
        dialogue = GameObject.Find("DialogueHandler").GetComponent<DialogueHandler>();
        inventory = GameObject.Find("InventoryHandler").GetComponent<InventoryHandler>();
    }

    public void Interract()
    {
        if (inventory.hasKeys)
        {
            dialogueText = null;
            doorClosedBg.SetActive(false);
            doorOpenBg.SetActive(true);
            Destroy(this);

        }
        if (!inventory.hasKeys)
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
}
