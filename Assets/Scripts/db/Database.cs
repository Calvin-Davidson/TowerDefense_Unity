using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

public class Database : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Start()
    {
        StartCoroutine(GetScore());
    }

    public void UpdateHighScoreInDataBase()
    {
        StartCoroutine(UpdateHighScore());
    }
    
    public IEnumerator UpdateHighScore()
    {
        WWW request = new WWW("http://29150.hosts2.ma-cloud.nl/UnityDB/Write.php?name='" + player.GetName() + "'&score=" + player.GetScore());

        yield return request;
        Debug.Log("create: " + request.text);
    }
    public IEnumerator GetScore()
    {
        WWW request = new WWW("http://29150.hosts2.ma-cloud.nl/UnityDB/Read.php?name='" + player.GetName() + "'");
        
        yield return request;
        try
        {
            int hs = Int32.Parse(request.text);
            player.SetHighScore(hs);
        }
        catch (FormatException e)
        {
            player.SetHighScore(0);
        }
    }
}
