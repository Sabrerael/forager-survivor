using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] int damage = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter");
        other.gameObject.GetComponent<Health>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
