using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] int damage = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            Debug.Log("OnTriggerEnter");
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int value) {
        damage = value;
    }
}
