using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public bool hasKeys = false;
    public bool hasName = false;
    public DialogueHandler dialogue;
    public Button keysButton;
    private void Awake()
    {
        dialogue = GameObject.Find("DialogueHandler").GetComponent<DialogueHandler>();

    }

    private void Update()
    {
        if (hasKeys)
        {
            keysButton.enabled = false;
        }
    }

    public void GetKeys()
    {
        if (!dialogue.textIsActive)
        {
            hasKeys = true;
        }
    }
    public void GetName()
    {
        hasName = true;
    }
}
