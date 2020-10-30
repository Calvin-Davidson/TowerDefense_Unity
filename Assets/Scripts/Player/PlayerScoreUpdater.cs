using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Player player;
   
    public void UpdateScore()
    {
        scoreText.text = "score: " + player.GetScore();
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "Highscore: " + player.GetHighScore();
    }
}
