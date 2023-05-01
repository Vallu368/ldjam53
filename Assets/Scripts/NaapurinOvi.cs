using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaapurinOvi : MonoBehaviour
{
    public InventoryHandler inventory;
    public Button naapurinOviButton;
    void Start()
    {
        inventory = GameObject.Find("InventoryHandler").GetComponent<InventoryHandler>();
    }
    private void Awake()
    {
        naapurinOviButton.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (inventory.hasName)
        {
            naapurinOviButton.enabled = true;
        }
        else naapurinOviButton.enabled = false;
    }
}
