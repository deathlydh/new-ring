using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private GameObject gameOverPanel;

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
        ShowGameOverPanel();  // ���������� ������ Game Over
        // ����� ����� �������� ������ ����������� ������, ���� �����.
    }

    private void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // ���������� ������ Game Over
        }
        else
        {
            Debug.LogWarning("Game Over Panel is not assigned!");
        }
    }
}
