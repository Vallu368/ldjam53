using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePosition;
    }
}
