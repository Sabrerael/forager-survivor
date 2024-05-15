using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private Movement movement;
    private Gun gun;

    private void Start() {
        movement = GetComponent<Movement>();
        gun = GetComponent<Gun>();
    }

    private void OnFire(InputValue value) {
        gun.isFiring = value.isPressed;
    } 

    private void OnMove(InputValue value) {      
        movement.SetMovementValues(value.Get<Vector2>());
    }
}
