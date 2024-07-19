using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.5f;
    [SerializeField] int damageValue = 1;

    private Enemy lockedEnemy;
    private Coroutine firingCoroutine;

    private void Update() {
        FindEnemyInRange();
        
        if (lockedEnemy != null && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContiniously());
        } else if (lockedEnemy == null && firingCoroutine != null) { 
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private void FindEnemyInRange() {
        throw new NotImplementedException();
    }

    private IEnumerator FireContiniously() {
        while(true) {
                Projectile instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                instance.SetDamage(damageValue);
                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                if (rb != null) {
                    Vector2 direction = lockedEnemy.transform.position - transform.position;
                    rb.velocity = direction.normalized * projectileSpeed;
                    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    instance.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                }
                Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
