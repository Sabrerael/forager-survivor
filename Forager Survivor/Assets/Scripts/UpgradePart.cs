using UnityEngine;

public class UpgradePart : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && other.GetComponent<Inventory>()) {
            other.GetComponent<Inventory>().AddUpgradePart();
            Destroy(gameObject);
        }
    }
}
