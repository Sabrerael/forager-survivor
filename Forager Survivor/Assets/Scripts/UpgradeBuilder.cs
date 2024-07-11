using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO Lots of overlap, can be consolidated
public class UpgradeBuilder : MonoBehaviour
{
    [SerializeField] GameObject upgradeBuilding;

    private Inventory inventory;
    private Vector3 spawningPosition;

    private void Awake() {
        inventory = GetComponent<Inventory>();
    }

    public void StartBuilding() {
        if (inventory.GetUpgradeParts() >= 5) {
            spawningPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Instantiate(upgradeBuilding, new Vector3(spawningPosition.x, spawningPosition.y, 0), Quaternion.identity);
            inventory.UseUpgradeParts(5);
        }
    }
}
