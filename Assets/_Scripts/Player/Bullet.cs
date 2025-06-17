using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageDealer
{
    public int bulletDamage;
    public int Damage => bulletDamage;
    public float lifeTime = 2f;

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
        BulletPool.Intacne.DespawnBullet(this.gameObject);
    }
    public void SetDamage(int damage)
    {
        bulletDamage = damage;
    }

}
