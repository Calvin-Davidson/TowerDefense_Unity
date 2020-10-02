using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultTower : SingleTargetTower
{
    private readonly int _swing = Animator.StringToHash("Swing");

    protected override void Attack()
    {
        AttackAnimation();
        base.Attack();
    }

    protected override void AttackAnimation()
    {
        Debug.Log("swing");
        animator.SetBool(_swing, true);
    }
}