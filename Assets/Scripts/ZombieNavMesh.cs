using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavMesh : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;
   // private ZombieHealth zombieHealth;

    [SerializeField] private float attackRange = 2f; // Дистанция атаки
    [SerializeField] private float attackCooldown = 2f; // Задержка между атаками
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       // zombieHealth = GetComponent<ZombieHealth>();
    }

    void Update()
    {
       // if (zombieHealth.IsDead)
       // {
            // Зомби мёртв
       //     animator.SetBool("IsDead", true);
       //     agent.isStopped = true; // Останавливаем движение
       //     return;
       // }

        // Расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Атака
            animator.SetBool("IsAttacking", true);
            agent.isStopped = true; // Останавливаем движение

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // Наносим урон игроку
              //  PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
              //  if (playerHealth != null)
              //  {
               //     playerHealth.TakeDamage(10); // Пример урона
               // }
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // Движение к игроку
            animator.SetBool("IsAttacking", false);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }

        // Управление анимацией ходьбы
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
