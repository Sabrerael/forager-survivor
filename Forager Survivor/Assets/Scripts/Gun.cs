using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour {
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.5f;

    public bool isFiring;
    private Coroutine firingCoroutine;

    private void Update() {
        Fire();
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
            Debug.Log(getMousePosition());
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 direction = getMousePosition() - transform.position;
                rb.velocity = direction.normalized * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }

    private Vector3 getMousePosition() {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
