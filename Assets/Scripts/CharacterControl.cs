using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class CharacterControl : MonoBehaviour {

	public float animationSpeed = 1.5f;
	
	private Animator animator;
	
	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		
		animator.SetFloat("Speed", v);
		animator.SetFloat("Direction", h);
		animator.speed = animationSpeed;
		
		animator.SetBool("Attack", Input.GetButton("Fire1"));
	}
}
