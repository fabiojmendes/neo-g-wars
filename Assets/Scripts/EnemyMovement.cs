using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	GameObject player;

	float speed = 6f; 
	float range = 1000f;
	float hitRange = 5f;
	float enemyDamage = 10f;
	float rotationSpeed = 5f;
	float damageTimer = 0f;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");	
	}
		
	void Update() {
	
	    //move towards player
	
	    float distance = Vector3.Distance(transform.position, player.transform.position);
	
	    if(distance <= range) {
	        Vector3 delta = player.transform.position - transform.position;
	        delta.Normalize();
	        delta.y = 0;
			
	        float moveSpeed = speed * Time.deltaTime;
	        transform.position = transform.position + (delta * moveSpeed);
	        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), rotationSpeed * Time.deltaTime);
	        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	        
			damageTimer += Time.deltaTime;
	        
			if (distance < hitRange && damageTimer>=1.5) {
	            damageTimer = 0f;
	            player.SendMessageUpwards("ApplyDamage", enemyDamage, SendMessageOptions.DontRequireReceiver);
	        }
	    }
	}
}
