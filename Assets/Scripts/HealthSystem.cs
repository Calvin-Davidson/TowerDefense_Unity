using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public UnityEvent onTakeDamage;
    public UnityEvent onDie;

    [SerializeField] protected float startingHealth = 100;
    protected float CurrentHealth;

    void Awake()
    {
        CurrentHealth = startingHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0) onDie.Invoke();
        onTakeDamage.Invoke();
    }

    public float GetCurrentHealth()
    {
        return this.CurrentHealth;
    }

    public float GetStartingHealth()
    {
        return this.startingHealth;
    }
}