using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile,gun; 

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){
		animator = GetComponent<Animator> ();
		projectileParent = GameObject.Find ("projectileParent");
		SetMyLaneSpawner ();
		print (myLaneSpawner);
		if (projectileParent) {
			return;
		} else {
			projectileParent=new GameObject("projectileParent");
		}

	}
	void Update(){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private void Fire(){
		GameObject newProjectile=Instantiate (projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	void SetMyLaneSpawner(){

		Spawner[] newSpawner =FindObjectsOfType(typeof(Spawner))as Spawner[];
		foreach (Spawner look in newSpawner) {
			if (look.transform.position.y == gameObject.transform.position.y) {
				myLaneSpawner = look;
			}
		}

	}
	bool IsAttackerAheadInLane(){
		if (myLaneSpawner.transform.childCount<=0) {
			return false;
		} 
		foreach(Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x>transform.position.x){
				return true;
			}
		}
		return false;
	}
}
