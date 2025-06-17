using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int bulletDamage = 10;
    public void SetDamage(int damage)
    {
        bulletDamage = damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //IDamageable damageable = collision.GetComponent<IDamageable>();

        if (collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.TakeDamage(bulletDamage);
            Despawn();
        }

    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
