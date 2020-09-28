using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class PathFollower : MonoBehaviour
{
    [SerializeField] private UnityEvent pathEndReach;
    [SerializeField] private Path path;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;

    private void Awake()
    {
        pathEndReach.AddListener(EndReach);
    }

    private void Update()
    {
        if (path.GetCurrentWayPoint().Equals(null)) return;
        Vector3 entityPos = transform.position;
        Vector3 targetPos = path.GetCurrentWayPoint().Position;
        transform.position = Vector3.MoveTowards(entityPos, targetPos, speed * Time.deltaTime);

        targetPos.y = entityPos.y;
        if (transform.position != targetPos) return;

        if (path.Next()) return;
        pathEndReach.Invoke();
        Destroy(this.gameObject);
    }


    void EndReach()
    {
        pathEndReach.RemoveListener(EndReach);
        GameObject.Find("Player").GetComponent<HealthSystem>().TakeDamage(damage);
    }
}