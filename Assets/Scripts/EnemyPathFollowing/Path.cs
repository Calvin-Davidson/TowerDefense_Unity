using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Waypoint> moveTo = new List<Waypoint>();
        private int _currentWayPoint = 0;
        
        public bool Next()
        {
            _currentWayPoint += 1;
            return (_currentWayPoint < moveTo.Count);
        }

        public bool Previous()
        {
            _currentWayPoint -= 1;
            return (_currentWayPoint > 0);
        }
        
        public Waypoint GetCurrentWayPoint()
        {
            if (_currentWayPoint >= moveTo.Count) return null;
            return moveTo[_currentWayPoint];
        }
    }