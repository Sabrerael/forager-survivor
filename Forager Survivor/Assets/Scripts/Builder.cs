using UnityEngine;
using UnityEngine.InputSystem;

public class Builder : MonoBehaviour {
    [SerializeField] GameObject building;

    private Inventory inventory;
    private Vector3 spawningPosition;

    private void Awake() {
        inventory = GetComponent<Inventory>();
    }

    public void StartBuilding() {
        if (inventory.GetScrap() >= 5) {
            spawningPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Instantiate(building, new Vector3(spawningPosition.x, spawningPosition.y, 0), Quaternion.identity);
            inventory.UseScrap(5);
        }
    }
}
