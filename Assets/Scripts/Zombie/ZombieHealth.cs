using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100f;
    private Animator animator;

    public bool IsDead { get; private set; }

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
        IsDead = true;
        animator.SetBool("IsDead", true);

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<ZombieController>().enabled = false;

        Destroy(gameObject, 5f);
    }
}
