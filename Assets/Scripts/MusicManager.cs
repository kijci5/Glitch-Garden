﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
	void Start(){
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume=PlayerPrefsManager.GetMasterVolume ();
	}
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic) {
			audioSource.clip=thisLevelMusic;
			audioSource.loop=true;
			audioSource.Play ();
		}
	}
	public void ChangeVolume(float vol){
		audioSource.volume = vol;
	}
}
