using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    private float lifeTime = 3f;
    private float currentLifeTime;
    [HideInInspector]
    public GameObject prefabOrigin;
    private Animator animator;

    private void OnEnable()
    {
        currentLifeTime = lifeTime;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("FireBall");
    }
    void Update()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            ReturnToPool();
        }
    }
    public void SetDamage(int damage)
    {
        bulletDamage = damage;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<IDamageable>(out var damageable)) return;
        damageable.TakeDamage(bulletDamage);

        ReturnToPool();
    }
    void ReturnToPool()
    {
        ObjectPoolingManager.Instance.ReturnObjectToPool("Bullet", gameObject);
    }

}
