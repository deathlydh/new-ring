using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100f;
    private Animator animator;

    public bool IsDead { get; private set; }

    public event Action OnDeath; // Событие смерти

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        health -= damage;
        if (health <= 0) Die();
    }

    private void Die()
    {
        if (IsDead) return;

        IsDead = true;
        animator.SetBool("IsDead", true);

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<ZombieController>().enabled = false;

        OnDeath?.Invoke(); 
        Destroy(gameObject, 5f);
    }
}
