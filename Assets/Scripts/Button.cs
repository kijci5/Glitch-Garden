using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;


	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color=Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
