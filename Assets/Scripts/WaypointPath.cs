using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public Vector3 GetWaypoint(int waypointIndex)
    {
        return positions[waypointIndex];
        
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == positions.Count)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }
}