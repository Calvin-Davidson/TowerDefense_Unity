using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowTower : SingleTargetTower
{
    protected override void Attack()
    {
        base.CanAttack();
    }
}
