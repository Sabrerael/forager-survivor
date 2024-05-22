using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private Movement movement;
    private Gun gun;
    private Builder builder;
    private Inventory inventory;

    private bool inBuildingContext;
    private Building building;

    private void Start() {
        movement = GetComponent<Movement>();
        gun = GetComponent<Gun>();
        builder = GetComponent<Builder>();
        inventory = GetComponent<Inventory>();
    }

    private void OnFire(InputValue value) {
        if (inBuildingContext) {
            building.StartBuilding(inventory.GetScrap());
            inventory.UseScrap(inventory.GetScrap());
        } else {
            gun.isFiring = value.isPressed;
        }
    } 

    private void OnMove(InputValue value) {      
        movement.SetMovementValues(value.Get<Vector2>());
    }

    private void OnBuild(InputValue value) {
        if (value.isPressed) {
            builder.StartBuilding();
        }
    }

    public void SetBuildingContext(Building building) {
        inBuildingContext = true;
        this.building = building;
    }

    public void UnsetBuildingContext() {
        inBuildingContext = false;
        this.building = null;
    }
}
