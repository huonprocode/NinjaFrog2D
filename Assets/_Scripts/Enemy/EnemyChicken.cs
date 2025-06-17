using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChicken : EnemyBase, IMovable
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(enemyData.moveSpeed * moveDirection * Time.deltaTime * Vector2.right);
    }

    public override void TakeDamage(int damageAmount)
    {
        animator.SetTrigger("IsDamage");
        base.TakeDamage(damageAmount);
    }
}
