using UnityEngine;
using System.Collections;

//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class EnemyMovement : MonoBehaviour {

    private Seeker seeker;

	public float hitRange = 5f;

    //The AI's speed per second
    public float speed = 5.0f;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3.0f;

	//The calculated path
	private Path path;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

	private Transform player;

	private float routeTimer = 0;

	private float routeTimerThreshold = 2.0f;

    public void Start () {
        seeker = GetComponent<Seeker>();

		player = GameObject.FindGameObjectWithTag("Player").transform;

		//controller = GetComponent<CharacterController>();
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
    }

    void OnPathComplete (Path p) {
        if (p.error) {
			Debug.Log ("Error: " + p);
        } else {
			Debug.Log ("Yey, we got a path back");
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
		}
    }

    void FixedUpdate () {
		routeTimer += Time.fixedDeltaTime;

        if (path == null) {
            //We have no path to move after yet
            return;
        }

		float distance = Vector3.Distance(transform.position, player.transform.position);
	    if(distance < hitRange) {
			return;
		}

		if (routeTimer > routeTimerThreshold && path.vectorPath[path.vectorPath.Count - 1] != player.transform.position) {
			Debug.Log ("Tracing new route");
			routeTimer = 0;
			path = null;
			seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
			return;
		}

        if (currentWaypoint >= path.vectorPath.Count) {
            Debug.Log ("End Of Path Reached");
			path = null;
			seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
            return;
        }

		MoveAndRotate();

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
        }
    }

	void MoveAndRotate() {
		transform.position = Vector3.Lerp(transform.position, path.vectorPath[currentWaypoint], speed * Time.fixedDeltaTime);
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5f * Time.fixedDeltaTime);
	    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}