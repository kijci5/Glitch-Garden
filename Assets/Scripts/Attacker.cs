using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]

public class Attacker : MonoBehaviour {

	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
	}
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("IsAttacking",false);
		}

	}
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	public void StrikeCurrentTarget(float damage){
		if (currentTarget) {
			Health health=currentTarget.GetComponent<Health> ();
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	public void Attack(GameObject obj){
		currentTarget = obj;
	}

}
