using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private float nextFireTime;
    private PlayerHealth health; // To check if alive

    void Start()
    {
        nextFireTime = 0f;
        health = GetComponent<PlayerHealth>(); // Link to health
    }

    void Update()
    {
        if (health != null && health.currentHealth <= 0) return; // Stop if dead

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Time.time >= nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * bulletSpeed;
    }
}