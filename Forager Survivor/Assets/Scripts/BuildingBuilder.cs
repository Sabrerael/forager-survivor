using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuilder : Building {
    [SerializeField] GameObject[] buildings;

    private Inventory inventory;
    private Vector3 spawningPosition;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<PlayerController>()) {
            other.gameObject.GetComponent<PlayerController>().SetBuildingContext(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<PlayerController>()) {
            other.gameObject.GetComponent<PlayerController>().UnsetBuildingContext();
        }
    }
}
