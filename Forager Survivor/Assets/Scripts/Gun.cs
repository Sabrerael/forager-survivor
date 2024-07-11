using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO: Can bypass the firingRate by clicking rapidly, will need to fix
public class Gun : MonoBehaviour {
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.5f;

    public bool isFiring;

    private int upgradeCount = 0;
    private int bulletCount = 1;
    private int damageValue = 1;
    private Coroutine firingCoroutine;

    private void Update() {
        Fire();
        RotatePlayer();
    }
    
    public void UpgradeGun() {
        if (upgradeCount % 3 == 0) {
            firingRate /= 2f;
        } else if (upgradeCount % 3 == 1) {
            bulletCount++;
        } else if (upgradeCount % 3 == 2) {
            damageValue++;
        }
    }

    private void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContiniously());
        } else if (!isFiring && firingCoroutine != null) { 
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContiniously() {
        while(true) {
            Projectile instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            instance.SetDamage(damageValue);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 direction = GetMousePosition() - transform.position;
                rb.velocity = direction.normalized * projectileSpeed;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                instance.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }

    private Vector3 GetMousePosition() {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void RotatePlayer() {
        var screenPoint = GetMousePosition();
        var offset = new Vector2(
            screenPoint.x - transform.position.x,
            screenPoint.y - transform.position.y
        );
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
