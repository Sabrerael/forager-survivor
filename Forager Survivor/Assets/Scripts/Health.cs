using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] int healthPoints = 10;
    [SerializeField] TextMeshProUGUI healthText;

    private int currentHealthPoints;

    private void Start() {
        currentHealthPoints = healthPoints;    
    }

    public int GetHealthPoints() {
        return healthPoints;
    }

    public void TakeDamage(int damage) {
        currentHealthPoints -= damage;

        if (healthText != null) {
            healthText.text = "Health: " + currentHealthPoints;
        }

        if (currentHealthPoints <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
        if (gameObject.CompareTag("Enemy")) {
            GetComponent<Enemy>().SpawnScrap();
            FindObjectOfType<PlayerController>().IncreaseScore(100);
        }
    }
}
