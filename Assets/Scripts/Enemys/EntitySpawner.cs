using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private int secondsBetweenSpawn;
    [SerializeField] private GameObject enemy;
    void Start()
    {
        Invoke(nameof(Spawn), secondsBetweenSpawn);
    }

    private void Spawn()
    {
        enemy = Instantiate(enemy, transform.position, Quaternion.identity);        
    }
}
