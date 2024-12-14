using UnityEngine;

public class FollowThePath : MonoBehaviour {
    // Waypoints array that Enemy walks along
    // assigned in SpawningManager when Enemy is spawned
    public Transform[] waypoints;

    public float pathLength;

    // Move speed assigned in SpawningManager when Enemy is spawned
    public float moveSpeed;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

	// Use this for initialization
	private void Start () {
        
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {

        // Move Enemy
        Move();
	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.LookAt(waypoints[waypointIndex].transform.position);
            transform.position = Vector3.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}