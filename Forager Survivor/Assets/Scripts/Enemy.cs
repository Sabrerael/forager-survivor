using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        var direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime;
    }
}
