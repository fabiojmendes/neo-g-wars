using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	Plane playerMovementPlane;
	
	Quaternion screenMovementSpace;
	Vector3 screenMovementForward;
	Vector3 screenMovementRight;
	
	//string debugOutput;
	
	void Awake() {
		// caching movement plane
		playerMovementPlane = new Plane (transform.up, transform.position);
	}

	void Start() {
		screenMovementSpace = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0);
		screenMovementForward = screenMovementSpace * Vector3.forward;
		screenMovementRight = screenMovementSpace * Vector3.right;
		Debug.Log("ScreenMvSpc: " + screenMovementSpace);
		Debug.Log("ScreenMvFw: " + screenMovementForward);
		Debug.Log("ScreenMvR: " + screenMovementRight);
	}

	void Update() {
		
		Vector3 cameraAdjustmentVector = Vector3.zero;
		
		// On PC, the cursor point is the mouse position
		Vector3 cursorScreenPosition = Input.mousePosition;
					
		// Find out where the mouse ray intersects with the movement plane of the player
		Vector3 cursorWorldPosition = ScreenPointToWorldPointOnPlane (cursorScreenPosition, playerMovementPlane, Camera.main);
		
		float halfWidth = Screen.width / 2.0f;
		float halfHeight = Screen.height / 2.0f;
		float maxHalf = Mathf.Max (halfWidth, halfHeight);
		
		// Acquire the relative screen position			
		Vector3 posRel = cursorScreenPosition - new Vector3(halfWidth, halfHeight, cursorScreenPosition.z);		
		posRel.x /= maxHalf; 
		posRel.y /= maxHalf;
					
		cameraAdjustmentVector = posRel.x * screenMovementRight + posRel.y * screenMovementForward;
		cameraAdjustmentVector.y = 0;	
								
		// The facing direction is the direction from the character to the cursor world position
		Vector3 facingDirection = (cursorWorldPosition - transform.position);
		facingDirection.y = 0;
		
		//transform.rotation = Quaternion.FromToRotation(transform.position, facingDirection);
		
		float rotationAngle = AngleAroundAxis (transform.forward, facingDirection, Vector3.up);
		transform.Rotate(Vector3.up, rotationAngle);
		
		//debugOutput = facingDirection.ToString();
	}
	
	Vector3 PlaneRayIntersection(Plane plane, Ray ray) {
		float dist;
		plane.Raycast(ray, out dist);
		return ray.GetPoint(dist);
	}
	
	Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera) {
		// Set up a ray corresponding to the screen position
		Ray ray = camera.ScreenPointToRay(screenPoint);
		
		// Find out where the ray intersects with the plane
		return PlaneRayIntersection (plane, ray);
	}
	
	// The angle between dirA and dirB around axis
	float AngleAroundAxis (Vector3 dirA, Vector3 dirB, Vector3 axis) {
	    // Project A and B onto the plane orthogonal target axis
	    dirA = dirA - Vector3.Project(dirA, axis);
	    dirB = dirB - Vector3.Project(dirB, axis);
	   
	    // Find (positive) angle between A and B
	    float angle = Vector3.Angle(dirA, dirB);
	   
	    // Return angle multiplied with 1 or -1
	    return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
	}

	/*
	void OnGUI() {
		GUI.TextArea(new Rect(10, 10, Screen.height - 10, Screen.width - 10), debugOutput);
	}
	*/
}
