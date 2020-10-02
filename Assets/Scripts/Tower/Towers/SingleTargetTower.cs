using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTower : BaseTower
{
    protected override void Attack()
    {
        foreach (var target in Targets)
        {
            target.enemyHealth.TakeDamage(damage);
        }
        Targets.Clear();
    }

    protected override bool CanAttack()
    {
        Enemy enemy = EnemyInRangeChecker.GetClosestEnemyInRange();
        if (enemy == null) return false;
        Targets.Add(enemy);
        return true;
    }
}
