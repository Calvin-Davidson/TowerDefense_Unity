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
        private int currentWayPoint = 0;

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        public Boolean Next()
        {
            currentWayPoint += 1;
            return (currentWayPoint < moveTo.Count);
        }

        public Waypoint getCurrentWaypoint()
        {
            if (currentWayPoint >= moveTo.Count) return null;
            return moveTo[currentWayPoint];
        }
    }