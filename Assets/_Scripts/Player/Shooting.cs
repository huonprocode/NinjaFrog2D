using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private PlayerStats playerStats;
    public float bulletSpeed = 20;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;


    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        //ObjectPoolingManager.Instance.CreatePool(bulletPrefab, 10);
    }
    void Update()
    {
        HandleShooting();
    }
    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.J) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        float direction = transform.eulerAngles.y == 0 ? 1 : -1;

        GameObject bulletObj = ObjectPoolingManager.Instance.GetObjectFromPool("Bullet", bulletPrefab, firePoint.position, firePoint.rotation);
        bulletObj.GetComponent<Bullet>().SetDamage(playerStats.damage);
        if (bulletObj.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = bulletSpeed * direction * Vector2.right;
        }
    }
}
