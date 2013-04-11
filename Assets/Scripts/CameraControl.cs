using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public Transform character;
	public float damping = 5.0f;
	
	private Vector3 diff;
	
	// Use this for initialization
	void Start () {
		diff = this.transform.position - character.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 wantedPoint = character.position + diff;
		this.transform.position = Vector3.Lerp(this.transform.position, wantedPoint, Time.deltaTime * damping);
	}
}
