using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] int healthPoints = 10;

    private int currentHealthPoints;

    private void Start() {
        currentHealthPoints = healthPoints;    
    }

    public int GetHealthPoints() {
        return healthPoints;
    }

    public void TakeDamage(int damage) {
        currentHealthPoints -= damage;

        if (currentHealthPoints <= 0) {
            Die();
        }
    }

    private void Die() {
        Debug.Log("Die");
        Destroy(gameObject);
        if (gameObject.CompareTag("Enemy")) {
            GetComponent<Enemy>().SpawnScrap();
        }
    }
}
