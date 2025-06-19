using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int bulletDamage = 10;
    public float lifeTime = 4f;
    private float currentLifeTime;
    [HideInInspector]
    public GameObject enemyBulletPrefab;
    private void OnEnable()
    {
        currentLifeTime = lifeTime;
    }
    private void Update()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            Despawn();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.TakeDamage(bulletDamage);
            Despawn();
        }
    }
    public void SetDamage(int damage)
    {
        bulletDamage = damage;
    }
    void Despawn()
    {
        ObjectPoolingManager.Instance.ReturnObjectToPool("BulletEnemy", gameObject);
    }
}
