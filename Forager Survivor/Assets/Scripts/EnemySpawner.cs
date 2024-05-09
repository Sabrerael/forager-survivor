using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRadius = 10;
    [SerializeField] float minimumTimeBetweenSpawns = 1;
    [SerializeField] float maximumTimeBetweenSpawns = 2;
    [SerializeField] float waveLength = 15;
    [SerializeField] float breakLength = 10;

    private float timer = 0;

    private void Start() {
        StartCoroutine("EnemySpawns");   
    }

    private void Update() {
        timer += Time.deltaTime;
    }

    protected IEnumerator EnemySpawns() {
        while (true) {
            Debug.Log("Spawning");
            while (timer < waveLength) {
                Instantiate(enemyPrefab, Random.insideUnitCircle.normalized * spawnRadius, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(minimumTimeBetweenSpawns, maximumTimeBetweenSpawns));
            }
            Debug.Log("Done spawning");
            timer -= waveLength;
            yield return new WaitForSeconds(breakLength);
        }
    }
}
