using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected int delayBetweenAttacks = 10;
    [SerializeField] protected int damage = 10;
    protected EnemyInRangeChecker EnemyInRangeChecker;
    protected List<Enemy> Targets;

    private float AttackTimer = 0;

    void Awake()
    {
        Targets = new List<Enemy>();
        EnemyInRangeChecker = GetComponent<EnemyInRangeChecker>();
    }

    void Update()
    {
        AttackTimer += Time.deltaTime;
        if (AttackTimer > delayBetweenAttacks)
        {
            if (!CanAttack()) return;
            
            Attack();
            AttackTimer = 0;
        }
    }

    protected virtual void Attack()
    {
    }

    protected virtual bool CanAttack()
    {
        return false;
    }
}