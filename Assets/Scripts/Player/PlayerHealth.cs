using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player Health: {currentHealth}");
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // «десь можно добавить логику перезапуска уровн€
    }
}
