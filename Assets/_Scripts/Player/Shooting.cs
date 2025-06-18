using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPref;
    public float shootSpeed = 20;
    public float shootColdown = 2f;
    private float currentCooldown = 0f;
    PlayerStats playerStats;


    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        UpdateCooldown();
        HandleShooting();
    }
    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.J) && currentCooldown <= 0)
        {
            Shoot();
            currentCooldown = shootColdown;
        }
    }
    void Shoot()
    {
        float direction = transform.eulerAngles.y == 0 ? 1 : -1;

        GameObject bullet = BulletPool.Instance.SpawnBullet(firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetDamage(playerStats.damage);
        if (bullet.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = Vector2.right * shootSpeed * direction;
        }
    }
    void UpdateCooldown()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
