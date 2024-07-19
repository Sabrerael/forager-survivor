using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    private Movement movement;
    private Gun gun;
    private Builder builder;
    private UpgradeBuilder upgradeBuilder;
    private Inventory inventory;

    private bool inBuildingContext;
    private Building building;
    // TODO This will need to be removed/moved
    private int numberOfUpgradePartsNeeded = 1;
    private int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start() {
        movement = GetComponent<Movement>();
        gun = GetComponent<Gun>();
        builder = GetComponent<Builder>();
        upgradeBuilder = GetComponent<UpgradeBuilder>();
        inventory = GetComponent<Inventory>();
    }

    private void OnFire(InputValue value) {
        if (inBuildingContext) {
            if (building.GetType() == typeof(UpgradeBuilding)) {
                if (inventory.GetUpgradeParts() >= numberOfUpgradePartsNeeded) {
                    building.StartBuilding(1);
                    inventory.UseUpgradeParts(numberOfUpgradePartsNeeded);
                }
            } else {
                building.StartBuilding(inventory.GetScrap());
                inventory.UseScrap(inventory.GetScrap());
            }
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

    private void OnBuild2(InputValue value) {
        if (value.isPressed) {
            upgradeBuilder.StartBuilding();
        }
    }

    public void IncreaseScore(int score) {
        this.score += score;
        scoreText.text = "Score: " + this.score;
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
