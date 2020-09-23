using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (CurrentHealth <= 0)
        {
            
        }
    }
}