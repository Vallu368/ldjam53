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
    AudioSource openDoor;
    AudioSource examine;

    private void Awake()
    {
        dialogue = GameObject.Find("DialogueHandler").GetComponent<DialogueHandler>();
        inventory = GameObject.Find("InventoryHandler").GetComponent<InventoryHandler>();
        openDoor = GameObject.Find("OpenDoorSound").GetComponent<AudioSource>();
        examine = GameObject.Find("ExamineSound").GetComponent<AudioSource>();

    }

    public void Interract()
    {
        if (inventory.hasKeys)
        {
            Debug.Log("interracted with keys");
            openDoor.Play();
            dialogueText = null;
            doorClosedBg.SetActive(false);
            doorOpenBg.SetActive(true);
            Destroy(this.gameObject);

        }
        if (!inventory.hasKeys)
        {
            examine.Play();

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
