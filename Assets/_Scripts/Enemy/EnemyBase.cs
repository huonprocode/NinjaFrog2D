using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable, IDamageDealer
{
    public EnemyData enemyData;
    protected Animator animator;
    protected HealthBarCtrl healthBarCtrl;
    protected int moveDirection;
    private int currentHealth;
    public int Damage => enemyData.damage;

    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        healthBarCtrl = GetComponentInChildren<HealthBarCtrl>();
    }
    protected virtual void Start()
    {
        currentHealth = enemyData.maxHealth;
        healthBarCtrl.UpdateHealthBar(currentHealth, enemyData.maxHealth);

        moveDirection = transform.position.x > 0 ? -1 : 1;
        if (moveDirection > 0)
        {
            FlipSprite();
        }
    }

    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        healthBarCtrl.UpdateHealthBar(currentHealth, enemyData.maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
        Instantiate(enemyData.expPrefab, transform.position, transform.rotation);
    }
}
