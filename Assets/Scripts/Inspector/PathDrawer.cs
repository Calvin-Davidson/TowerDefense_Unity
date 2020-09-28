using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConnectedObjects))]
public class PathDrawer : Editor
{
    void OnSceneGUI()
    {
        ConnectedObjects connectedObjects = target as ConnectedObjects;
        if (connectedObjects == null) return;
        Waypoint[] waypoints = connectedObjects.GetComponentsInChildren<Waypoint>();
        if (waypoints.Length <= 0) return;


        for (int i = 1; i < waypoints.Length; i++)
        {
            Vector3 firstLocation = waypoints[i - 1].Position;
            Vector3 lastLocation = waypoints[i].Position;

            Handles.DrawLine(firstLocation, lastLocation);
        }
    }
}