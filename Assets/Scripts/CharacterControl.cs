using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	
	public float speed = 25.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");

		Vector3 direction = new Vector3(-h, 0, -v);
		direction.Normalize();
		direction *= Time.deltaTime * speed;
		
		// Move the controller
		CharacterController controller = GetComponent<CharacterController>();
		controller.Move(direction);

		Animator animator = GetComponent<Animator>();
		animator.SetFloat("Speed", controller.velocity.magnitude);
	}
}
