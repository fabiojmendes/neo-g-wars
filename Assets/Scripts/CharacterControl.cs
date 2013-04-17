using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour {

	public float animationSpeed = 1.5f;
	
	private CharacterController controller;
	private Animator animator;
	
	static int atttackState = Animator.StringToHash("Base Layer.atack1");
	
	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update() {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		
		Vector3 direction = new Vector3(-h, 0, -v);
		//direction.Normalize();
		
		// Move the controller
		//controller.Move(direction * Time.deltaTime * animationSpeed);
		
		//Vector3 result = transform - direction;
		animator.SetFloat("Speed", v);
		animator.SetFloat("Direction", h);
		animator.speed = animationSpeed;
		

		// ATACK
		AnimatorStateInfo currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentBaseState.nameHash == atttackState) {
			animator.SetBool("Atack", false);
		} else {
			animator.SetBool("Atack", Input.GetButton("Fire1"));
		}
	}
}
