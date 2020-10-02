using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetTower : BaseTower
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
        Enemy[] enemies = EnemyInRangeChecker.GetAllEnemiesInRange();
        if (enemies.Length <= 0) return false;
        foreach (var e in enemies) Targets.Add(e);
        return true;
    }
}