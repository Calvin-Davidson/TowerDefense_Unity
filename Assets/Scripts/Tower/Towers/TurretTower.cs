using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTower : BaseTower
{
    protected override void Attack()
    {
        GameObject target = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector3.Distance(obj.transform.position, transform.position) < Range)
            {
                target = obj;
            }
        }
        if (target == null) return;

        target.GetComponent<HealthSystem>().TakeDamage(Damage);
    }
}