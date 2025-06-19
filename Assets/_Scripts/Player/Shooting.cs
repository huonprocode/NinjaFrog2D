using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootSpeed = 20;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    PlayerStats playerStats;


    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        ObjectPoolingManager.Instance.CreatePool(bulletPrefab, 10);
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

        GameObject bulletObj = ObjectPoolingManager.Instance.GetObjectFromPool(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.prefabOrigin = bulletPrefab;
        bulletObj.GetComponent<Bullet>().SetDamage(playerStats.damage);
        if (bullet.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = Vector2.right * playerStats.attackSpeed * direction;
        }
    }
}
