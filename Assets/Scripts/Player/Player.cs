using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent highScoreUpdateEvent = new UnityEvent();
    [SerializeField] private UnityEvent scoreUpdateEvent = new UnityEvent();
    [SerializeField] private int money = 0;
    [SerializeField] private int score = 0;
    [SerializeField] private int highScore = 0;
    [SerializeField] private new string name = "Mr_Unknown";
    
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

    public void SetScore(int value)
    {
        this.score = value;
        if (this.score > highScore)
        {
            highScore = this.score;
            highScoreUpdateEvent.Invoke();
        }
        
        scoreUpdateEvent.Invoke();
    }

    public void SetHighScore(int value)
    {
        this.highScore = value;
        highScoreUpdateEvent.Invoke();
    }
    public int GetScore()
    {
        return this.score;
    }

    public int GetHighScore()
    {
        return this.highScore;
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetName(string value)
    {
        this.name = value;
    }
    
}
