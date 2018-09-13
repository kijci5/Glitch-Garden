using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public float autoLoadNextLevelAfter;

	private bool isRunning;
	private GameObject pauseGame;
	private GameObject coreGame;

	void Start(){
		isRunning = true;
		if (Application.loadedLevel > 2) {
			pauseGame = GameObject.Find ("Paused");
			coreGame = GameObject.Find ("CoreGame");
			pauseGame.SetActive (false);
		}
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disbaled");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	void Update(){
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				if(Application.loadedLevel<3){QuitRequest();}
				else{Pause ();}
			}
		}
	}
	public void QuitRequest(){
		Application.Quit ();
	}
	public void LoadLevel(string name){
		Application.LoadLevel (name);
	}
	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	public void Pause(){
		if (isRunning) {
			pauseGame.SetActive(true);
			coreGame.SetActive(false);
				Time.timeScale = 0;
				isRunning=false;
				
		}	else	if (isRunning==false){
			
			Time.timeScale = 1;
			isRunning=true;
			pauseGame.SetActive(false);
			coreGame.SetActive(true);
			
		}

	}
}
