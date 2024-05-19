using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Drag : MonoBehaviour {
    private Vector3 offset;

    private bool isDragging = true;

    private void Update() {
        if (isDragging) {
            Vector3 currentScreenPoint = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint + offset);
            Vector3 currentPositionAdjusted = new Vector3(currentPosition.x, currentPosition.y, 0);
            transform.position = new Vector3(Mathf.Round(currentPositionAdjusted.x), Mathf.Round(currentPositionAdjusted.y),0);
        }

        if (Mouse.current.leftButton.wasPressedThisFrame) {
            isDragging = false;
        }
    }
}
