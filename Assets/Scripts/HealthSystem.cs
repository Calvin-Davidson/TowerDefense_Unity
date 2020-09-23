using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;
    
    [SerializeField] protected float _StartingHealth = 100;
    protected float CurrentHealth;
    
    void Awake()
    {
        CurrentHealth = _StartingHealth;
    }
    public virtual void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0) OnDie.Invoke();
        OnTakeDamage.Invoke();
    }

    public float getCurrentHealth()
    {
        return this.CurrentHealth;
    }
    public float getStartingHealth()
    {
        return this._StartingHealth;
    }
}
