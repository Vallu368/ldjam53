using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseGraphic : MonoBehaviour
{
    public Image normalGraphic;
    public Image examineGraphic;
    public Image interractGraphic;


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        examineGraphic.enabled = false;
        interractGraphic.enabled = false;
    }

    void Update()
    {
             Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePosition;


    }
}
