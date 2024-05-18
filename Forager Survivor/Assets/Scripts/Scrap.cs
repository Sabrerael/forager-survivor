using UnityEngine;

public class Scrap : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && other.GetComponent<Inventory>()) {
            other.GetComponent<Inventory>().AddScrap();
            Destroy(gameObject);
        }
    }
}
