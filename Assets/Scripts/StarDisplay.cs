using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	private Text text;
	public static int stars = 100;
	public enum Status{SUCCES,FAILURE};
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = stars.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddStars(int amount){
		stars += amount;
		text.text = stars.ToString ();
	}
	public void UseStars(int amount){
		if (stars >= amount) {
			stars -= amount;
			text.text = stars.ToString ();
		}
	}
	void OnLevelWasLoaded(){
		stars = 100;
	}
}
