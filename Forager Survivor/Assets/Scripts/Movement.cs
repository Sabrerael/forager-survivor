using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float movementSpeed = 6;

    private Vector2 movementValues = new Vector2();
    private Rigidbody2D playerRigidbody;

    private void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (movementValues.magnitude > Mathf.Epsilon) {
            NormalMovement();
        }
    }

    public void NormalMovement() {
        playerRigidbody.AddForce(new Vector2(movementValues.x * movementSpeed,
                                             movementValues.y * movementSpeed));
    }

    public void SetMovementValues(Vector2 values) {
        movementValues = values;
    }
}
