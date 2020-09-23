using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected int delayBetweenAttacks = 10;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected float range = 0f;

    void Awake()
    {
        InvokeRepeating(nameof(Attack), 0, delayBetweenAttacks);
    }
    protected virtual void Attack()
    {
    }

    
    
    
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}