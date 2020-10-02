using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected int delayBetweenAttacks = 10;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected Animator animator;
    [SerializeField] private bool rotateToTarget = true;
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

        Enemy closest = EnemyInRangeChecker.GetClosestEnemyInRange();
        if (closest != null && rotateToTarget) RotateToTarget(closest.gameObject.transform.position);
        
        if (AttackTimer > delayBetweenAttacks)
        {
            if (!CanAttack()) return;
            
            Attack();
            AttackTimer = 0;
        }
    }

    private void RotateToTarget(Vector3 location)
    {
        Vector3 dir = location - transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 8f * Time.deltaTime);
    }

    protected virtual void Attack()
    {
    }
    protected virtual bool CanAttack()
    {
        return false;
    }
    protected virtual void AttackAnimation()
    {
        
    }
}