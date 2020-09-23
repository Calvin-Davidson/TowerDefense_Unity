using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private Image _healthbar;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (CurrentHealth <= 0) Destroy(this.gameObject);
    }
}