using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectButtons : MonoBehaviour
{
    [SerializeField] private TowerPlaceData towerPlaceData;
    [SerializeField] private GameObject towerPrefab;
    public void OnClick()
    {
        Debug.Log("SELECTED: " + towerPrefab.name);
        towerPlaceData.SetSelectedTower(towerPrefab);
    }
}
