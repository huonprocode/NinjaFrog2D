using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    public float lifeTime = 2f;
    [HideInInspector]
    public GameObject prefabOrigin;
    private Animator animator;

    private void OnEnable()
    {
        Invoke(nameof(Despawn), lifeTime);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("FireBall");
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<IDamageable>(out var damageable)) return;
        damageable.TakeDamage(bulletDamage);

        Despawn();
    }
    void Despawn()
    {
        ObjectPoolingManager.Instance.ReturnObjectToPool(prefabOrigin, gameObject);
        //BulletPool.Instance.DespawnBullet(gameObject);
    }
    public void SetDamage(int damage)
    {
        bulletDamage = damage;
    }
}
