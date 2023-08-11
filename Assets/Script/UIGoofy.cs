using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGoofy : MonoBehaviour
{
    public float movementSpeed = 5f; // The speed at which the object moves.

    [System.Serializable]
    public struct WaypointData
    {
        public Vector3 position;
        public Quaternion rotation;
        public bool shouldFlip;
    }

    public WaypointData[] waypoints; // Array to store the waypoints for movement.
    private int currentWaypointIndex = 0;

    private void Start()
    {
        // Set up the waypoints for movement.
        waypoints = new WaypointData[]
        {
            new WaypointData { position = new Vector3(-12f, 3f, 0f), rotation = Quaternion.Euler(0f, 0f, 0f), shouldFlip = false },
            new WaypointData { position = new Vector3(12f, 3f, 0f), rotation = Quaternion.Euler(0f, 0f, 90f), shouldFlip = true },
            new WaypointData { position = new Vector3(12f, -1.8f, 0f), rotation = Quaternion.Euler(0f, 0f, 180f), shouldFlip = false },
            new WaypointData { position = new Vector3(-12f, -1.8f, 0f), rotation = Quaternion.Euler(0f, 0f, 270f), shouldFlip = true },
        };

        // Set the initial position and rotation of the object.
        transform.position = waypoints[currentWaypointIndex].position;
        transform.rotation = waypoints[currentWaypointIndex].rotation;
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        // Move towards the current waypoint.
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the object has reached the current waypoint.
        if (transform.position == targetPosition)
        {
            // Check if the object should flip at this waypoint.
            if (waypoints[currentWaypointIndex].shouldFlip)
            {
                // Flip the object by rotating 180 degrees around the y-axis.
                transform.Rotate(Vector3.up, 180f);
            }

            // Move to the next waypoint or loop back to the first waypoint if at the end.
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
