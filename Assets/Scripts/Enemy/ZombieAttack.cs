using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    public void Attack(IDamageable target)
    {

        target?.TakeDamage(damage);
    }
}
