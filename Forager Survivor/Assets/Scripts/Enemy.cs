using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject scrapPrefab;

    GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        var direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime;
        RotateTowardsPlayer();
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
