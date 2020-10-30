using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour
{
    [SerializeField] private Player player;
    private float _floatScore;

    private void Awake()
    {
        _floatScore = 0;
    }

    private void Update()
    {
        _floatScore += Time.deltaTime;
        player.SetScore(Mathf.FloorToInt(_floatScore));
    }
}
