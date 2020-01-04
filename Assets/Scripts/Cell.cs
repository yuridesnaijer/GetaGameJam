using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    /// <summary>
    /// OnMouseUpAsButton is only called when the mouse is released over
    /// the same GUIElement or Collider as it was pressed.
    /// </summary>
    void OnMouseUpAsButton()
    {
        // GridManager.instance.ActivateCell(this.gameObject);
    }
}
