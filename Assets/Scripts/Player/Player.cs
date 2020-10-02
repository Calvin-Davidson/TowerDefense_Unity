using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int money = 0;

    public int GetMoney()
    {
        return this.money;
    }
    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
    public bool HasMoney(int amount)
    {
        return (money >= amount);
    }
}
