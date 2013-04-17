using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
public class CharacterControl : MonoBehaviour {
	
	
	public float animSpeed = 1.5f;
	
	
	private Animator anim;
	
	private AnimatorStateInfo currentBaseState;
	
	
	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int atackState = Animator.StringToHash("Base Layer.atack1");
	
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		
		anim.SetFloat("Speed", v);
		anim.SetFloat("Direction", h);
		anim.speed = animSpeed;
		
		Vector3 direction = new Vector3(-h, 0, -v);
		direction.Normalize();
		direction *= Time.deltaTime * animSpeed;
		
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		
		// Move the controller
		CharacterController controller = GetComponent<CharacterController>();
		controller.Move(direction);
		
		// ATACK
		
		if (currentBaseState.nameHash == locoState)
		{
			if(Input.GetButton("Fire1"))
			{
				anim.SetBool("Atack", true);
			}
		}
		
		
		// IDLE
		
		else if (currentBaseState.nameHash == idleState)
		{
			if(Input.GetButton("Fire1"))
			{
				anim.SetBool("Atack", true);
			}
		}
		else if(currentBaseState.nameHash == atackState)
		{
			anim.SetBool("Atack", false);
		}
	}
}
