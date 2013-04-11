using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Vector3 worldPosition = Input.mousePosition;
		//this.transform.LookAt(new Vector3(worldPosition.x, worldPosition.y, Camera.main.transform.position.y - this.transform.position.y));
		
		this.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
	
	void OnGUI() {
		GUI.Label(new Rect (10, 10, Screen.width - 10, Screen.height - 10), "Mouse " + Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
	}
}
