using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds=100;

	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private bool isEndOfLevel=false;
	private GameObject winButton;
	
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		winButton = GameObject.Find ("Win Button");
		winButton.SetActive(false);
		slider = GetComponent<Slider> ();
		slider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = (Time.timeSinceLevelLoad / levelSeconds);


		if (slider.value >= 1 && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winButton.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	static void DestroyAllTaggedObjects ()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("destroyOnWin");
		foreach (GameObject target in gameObjects) {
			GameObject.Destroy (target);
		}
	}

	void MovingSlider(){
		slider.value -= 1;
	}
	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
