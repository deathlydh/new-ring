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
    private Collider zombieCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        zombieCollider = GetComponent<Collider>();
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

        if (zombieCollider != null)
        {
            zombieCollider.enabled = false; // Отключаем коллайдер
        }


        OnDeath?.Invoke(); 
        Destroy(gameObject, 5f);
    }
}
