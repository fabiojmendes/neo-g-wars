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
	void Update () {
		Vector3 wantedPoint = character.position + diff;
		this.transform.position = Vector3.Lerp(this.transform.position, wantedPoint, Time.deltaTime * damping);
	}

	/*
	void OnGUI() {
		GUI.Label(new Rect (10, 10, Screen.width-10, Screen.height-10), "Char " + character.position.ToString());
		GUI.Label(new Rect (10, 25, Screen.width-10, Screen.height-10), "Camera " + this.transform.position.ToString());
		GUI.Label(new Rect (10, 40, Screen.width-10, Screen.height-10), "Diff " + diff.ToString());
		GUI.Label(new Rect (10, 55, Screen.width-10, Screen.height-10), "Wanted " + (character.position + diff).ToString());
	}*/
}
