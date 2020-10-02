using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeChecker : MonoBehaviour
{
    [Range(0, 20f)] public float range;

    [SerializeField] private LayerMask layerMask;

    public Enemy[] GetAllEnemiesInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, range, layerMask);
        if (cols.Length < 1) return new Enemy[0];
        
        Enemy[] enemies = new Enemy[cols.Length];
        for (int i = 0; i < cols.Length; i++) enemies[i] = cols[i].GetComponent<Enemy>();
        return enemies;
    }

    public Enemy GetClosestEnemyInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, range, layerMask);
        if (cols.Length < 1) return null;
        return cols[0].GetComponent<Enemy>();
    }

    public Enemy[] GetAllEnemiesInRangeFromLocation(Vector3 pos, float radius)
    {
        Collider[] cols = Physics.OverlapSphere(pos, radius, layerMask);
        if (cols.Length < 1) return null;
        
        Enemy[] enemies = new Enemy[cols.Length];
        for (int i = 0; i < cols.Length; i++) enemies[i] = cols[i].GetComponent<Enemy>();
        return enemies;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}