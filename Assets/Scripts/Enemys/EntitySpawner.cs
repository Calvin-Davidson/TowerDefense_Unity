using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private int _secondsBetweenSpawn;
    [SerializeField] private GameObject _enemy;
    void Awake()
    {
        StartCoroutine(Timer());
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_secondsBetweenSpawn);
        _enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        StartCoroutine(Timer());
    }
}
