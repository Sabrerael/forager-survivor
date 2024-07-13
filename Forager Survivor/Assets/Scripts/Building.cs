using UnityEngine;

// TODO Need to create a Recipe class (contains the input, the output, and the build duration)
public class Building : MonoBehaviour {
    [SerializeField] protected float buildTime = 5;
    [SerializeField] GameObject upgradePart;

    protected int itemsToBuild = 0;
    protected int builtItems = 0;
    protected float timer = 0;

    private void Update() {
        if (itemsToBuild > 0) {
            BuildItems();
        }
    }

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

    public virtual void StartBuilding(int value) {
        Debug.Log("StartBuilding called with " + value);
        itemsToBuild += value;
    }

    protected virtual void BuildItems() {
        timer += Time.deltaTime;
        if (timer >= buildTime) {
            Instantiate(upgradePart, transform.position + new Vector3(0, -1.75f, 0), Quaternion.identity);
            builtItems++;
            timer = 0;
            if (builtItems == itemsToBuild) {
                builtItems = 0;
                itemsToBuild = 0;
                Debug.Log("Done Building");
            }
        }  
    }
}
