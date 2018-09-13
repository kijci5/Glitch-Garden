using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Camera c;
	private GameObject Defenders;
	private StarDisplay starDisplay;

	void Start () {
		c = FindObjectOfType<Camera> ();
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		Defenders = GameObject.Find ("Defenders");
		if (Defenders) {
			return;
		} else {
			Defenders=new GameObject("Defenders");
		}

	}
	void OnMouseDown(){
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (defenderCost<=StarDisplay.stars) {
			GameObject newDefender = Instantiate (defender, SnapToGrid (CalculateWorldPointOfMouseClick ()), Quaternion.identity)as GameObject;
			newDefender.transform.parent = Defenders.transform;
			starDisplay.UseStars (defenderCost);
		} else {
			Debug.Log ("Insufficient stars");
		}
	}
	Vector2 SnapToGrid(Vector2 rawWorldPos){
		int newX = Mathf.RoundToInt (rawWorldPos.x);
		int newY = Mathf.RoundToInt (rawWorldPos.y);

		return new Vector2 (newX, newY);
	}
	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distance = 10f;

		Vector3 weirdVector = new Vector3 (mouseX, mouseY, distance);
		Vector2 worldPos = c.ScreenToWorldPoint (weirdVector);
		return worldPos;
	}
}
