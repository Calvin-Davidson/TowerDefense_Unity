using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerPlaceData : MonoBehaviour
{
    private GameObject _selectedTower;



    public GameObject GetSelectedTower()
    {
        return _selectedTower;
    }
    public void SetSelectedTower(GameObject tower)
    {
        _selectedTower = tower;
    }
}
