using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected int DelayBetweenAttacks = 10;
    [SerializeField] protected int Damage = 10;
    [SerializeField] protected float Range = 0f;

    void Awake()
    {
        StartCoroutine(AttackTimer());
    }
    protected virtual void Attack()
    {
    }
    private IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(DelayBetweenAttacks);
        Attack();
        StartCoroutine(AttackTimer());
    }
}