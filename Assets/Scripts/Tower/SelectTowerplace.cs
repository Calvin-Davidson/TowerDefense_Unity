using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectTowerplace : MonoBehaviour
{
    public TowerPlaceData towerPlaceData;

    [SerializeField] private LayerMask layerMask;
    void Update () {
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast (ray,out hit,Mathf.Infinity, layerMask)) {
                // place selected tower.
                
                GameObject selectedTower = towerPlaceData.GetSelectedTower();
                if (selectedTower == null) return;

                // als de geselecteerde tower place al een toren heeft, we willen geen 100 torrens op 1 plek.
                if (hit.collider.gameObject.GetComponentsInChildren<BaseTower>().Length > 0) return;
                
                Vector3 pos = new Vector3(0,0.1f,0);
                GameObject spawnedTower = Instantiate(selectedTower, pos, Quaternion.identity);
                spawnedTower.transform.SetParent(hit.collider.gameObject.transform);
                spawnedTower.transform.localPosition = pos;
            } 
        }
    }
}