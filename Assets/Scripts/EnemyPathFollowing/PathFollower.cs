using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class PathFollower : MonoBehaviour
{
    [SerializeField] private UnityEvent _pathEndReach;
    [SerializeField] private Path _path;
    [SerializeField] private float _speed = 5f;
    
    void Update()
    {
        if (_path.getCurrentWaypoint().Equals(null)) return;
        
        Vector3 targetPos = _path.getCurrentWaypoint().Position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPos);
        if (transform.position != targetPos) return;

        if (_path.Next()) return;
        _pathEndReach.Invoke();
        Destroy(this.gameObject);
    }
}