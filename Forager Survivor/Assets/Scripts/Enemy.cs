using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject scrapPrefab;
    [SerializeField] float movementSpeed = 2;

    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
    }

    private void Update() {
        if (player != null) {
            var direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * (movementSpeed * Time.deltaTime);
            RotateTowardsPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == player) {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.TakeDamage(1);
        }
    }

    public void SpawnScrap() {
        Instantiate(scrapPrefab, transform.position, Quaternion.identity);
    }

    private void RotateTowardsPlayer() {
        var offset = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y
        );
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
