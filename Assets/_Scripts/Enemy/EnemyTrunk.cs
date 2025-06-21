using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyTrunk : EnemyBase, IMovable, IAttacker
{
    float attackTimer = 2f;
    [SerializeField] private float attackCooldown = 1f;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    protected override void Start()
    {
        base.Start();
    }
    void Update()
    {
        Attack();
        Move();
    }

    public void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            animator.SetTrigger("IsAttack");
            GameObject bulletObj = ObjectPoolingManager.Instance.GetObjectFromPool("BulletEnemy",enemyBulletPrefab, firePoint.position, firePoint.rotation);
            //BulletEnemy bullet = bulletObj.GetComponent<BulletEnemy>();
            //bullet.enemyBulletPrefab = enemyBulletPrefab;

            if (moveDirection < 0)
            {
                bulletObj.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (bulletObj.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.velocity = new Vector2(moveDirection, 0) * 5;
            }
            bulletObj.GetComponent<BulletEnemy>().SetDamage(enemyData.damage);
            attackTimer = 0f;
        }
    }

    public void Move()
    {
        transform.Translate(enemyData.moveSpeed * moveDirection * Time.deltaTime * Vector2.right);
    }
    public override void TakeDamage(int damageAmount)
    {
        animator.SetTrigger("IsHit");
        base.TakeDamage(damageAmount);
    }

}
