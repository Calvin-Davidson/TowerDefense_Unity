using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class PathFollower : MonoBehaviour
{
    [SerializeField] private UnityEvent pathEndReach;
    [SerializeField] private Path path;
    [SerializeField] private float speed = 5f;
    
    private void Update()
    {
        if (path.GetCurrentWayPoint().Equals(null)) return;

        Vector3 targetPos = path.GetCurrentWayPoint().Position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        if (transform.position != targetPos) return;

        if (path.Next()) return;
        pathEndReach.Invoke();
        Destroy(this.gameObject);
    }
}