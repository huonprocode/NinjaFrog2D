using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    Animator animator;
    PlayerStats playerStats;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        playerStats.currentHealth = playerStats.maxHealth;
        EventManager.Intance.HealthChanged(playerStats.currentHealth, playerStats.maxHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<IDamageDealer>(out var damageDealer)) return;
        TakeDamage(damageDealer.Damage);
    }
    public void TakeDamage(int damageAmount)
    {
        animator.SetTrigger("Damage");

        playerStats.currentHealth -= damageAmount;
        playerStats.currentHealth = Mathf.Max(playerStats.currentHealth, 0);
        EventManager.Intance.HealthChanged(playerStats.currentHealth, playerStats.maxHealth);
        if (playerStats.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        EventManager.Intance.PlayerDie();
    }

}
