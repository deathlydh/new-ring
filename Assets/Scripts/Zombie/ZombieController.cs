using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 2f;

    private Transform player;
    private UnityEngine.AI.NavMeshAgent agent;
    private ZombieHealth zombieHealth;
    private ZombieAttack zombieAttack;
    private ZombieAnimatorController animatorController;

    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        zombieHealth = GetComponent<ZombieHealth>();
        zombieAttack = GetComponent<ZombieAttack>();
        animatorController = GetComponent<ZombieAnimatorController>();
    }

    void Update()
    {
        if (zombieHealth.IsDead)
        {
            agent.isStopped = true;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool isAttacking = distanceToPlayer <= attackRange;

        if (isAttacking)
        {
            agent.isStopped = true;
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                var playerHealth = player.GetComponent<IDamageable>();
                if (playerHealth != null)
                {
                    zombieAttack.Attack(playerHealth);
                }
                lastAttackTime = Time.time;
            }
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }

        animatorController.UpdateState(agent.velocity.magnitude > 0.1f, isAttacking);
    }
}
