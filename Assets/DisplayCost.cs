using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayCost : MonoBehaviour {

	public GameObject defenderPrefab;
	private Text costText;
	// Use this for initialization
	void Start () {
		int cost = defenderPrefab.GetComponent<Defender> ().starCost;

		costText = GetComponentInChildren<Text> ();
		
		if (!costText) {
			Debug.LogWarning(name+" Cant find text");
		}
		costText.text = cost.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
