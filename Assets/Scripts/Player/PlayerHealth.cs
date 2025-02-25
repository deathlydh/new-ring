using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private HealthBar HealthBar;

    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.UpdateHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.UpdateHealth(currentHealth, maxHealth);
        //Debug.Log($"Player Health: {currentHealth}");
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        Debug.Log("Player died!");
        ShowGameOverPanel();  // ѕоказываем панель Game Over
        // «десь можно добавить логику перезапуска уровн€, если нужно.
    }

    private void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            DeathTimer deathTimer = gameOverPanel.GetComponent<DeathTimer>();
            if (deathTimer != null)
            {
                deathTimer.StartCountdown();
            }
        }
    }
}
