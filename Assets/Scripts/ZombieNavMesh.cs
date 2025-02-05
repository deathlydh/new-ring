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

    [SerializeField] private float attackRange = 2f; // ��������� �����
    [SerializeField] private float attackCooldown = 2f; // �������� ����� �������
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
            // ����� ����
       //     animator.SetBool("IsDead", true);
       //     agent.isStopped = true; // ������������� ��������
       //     return;
       // }

        // ���������� �� ������
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // �����
            animator.SetBool("IsAttacking", true);
            agent.isStopped = true; // ������������� ��������

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // ������� ���� ������
              //  PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
              //  if (playerHealth != null)
              //  {
               //     playerHealth.TakeDamage(10); // ������ �����
               // }
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // �������� � ������
            animator.SetBool("IsAttacking", false);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }

        // ���������� ��������� ������
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
