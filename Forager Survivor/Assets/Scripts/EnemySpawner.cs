using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRadius = 10;
    [SerializeField] float startingMinimumTimeBetweenSpawns = 1;
    [SerializeField] float startingMaximumTimeBetweenSpawns = 2;
    [SerializeField] float waveLength = 15;
    [SerializeField] float breakLength = 10;

    private float timer = 0;
    private float minimumTimeBetweenSpawns;
    private float maximumTimeBetweenSpawns;
    private int waveCount = 0;
    private int spawnsPerCount = 1;

    private void Start() {
        minimumTimeBetweenSpawns = startingMinimumTimeBetweenSpawns;
        maximumTimeBetweenSpawns = startingMaximumTimeBetweenSpawns;
        waveCount++;
        StartCoroutine("EnemySpawns");   
    }

    private void Update() {
        timer += Time.deltaTime;
    }

    private IEnumerator EnemySpawns() {
        while (true) {
            while (timer < waveLength) {
                for (int i = 0; i < spawnsPerCount; i++) {
                    Instantiate(enemyPrefab, Random.insideUnitCircle.normalized * spawnRadius, Quaternion.identity);
                }
                yield return new WaitForSeconds(Random.Range(minimumTimeBetweenSpawns, maximumTimeBetweenSpawns));
            }
            timer -= waveLength;
            yield return new WaitForSeconds(breakLength);
            ModifySpawnTimers();
        }
    }

    private void ModifySpawnTimers() {
        // TODO Will have to iterate on this
        minimumTimeBetweenSpawns = Mathf.Max(minimumTimeBetweenSpawns - 0.15f, 0);
        maximumTimeBetweenSpawns = Mathf.Max(maximumTimeBetweenSpawns - 0.15f, 0);
        waveCount++;
        if (waveCount % 10 == 0) {
            spawnsPerCount++;
        }
    }
}
