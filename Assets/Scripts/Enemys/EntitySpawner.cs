using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int secondsBetweenSpawn;
    void Start()
    {
        Invoke(nameof(Spawn), secondsBetweenSpawn);
    }

    private void Spawn()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);        
        Invoke(nameof(Spawn), secondsBetweenSpawn);
    }
}
