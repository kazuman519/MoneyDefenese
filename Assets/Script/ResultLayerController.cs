﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultLayerController : MonoBehaviour {
	public Text resultCashText;
	public AudioClip audioClipResultFail;
	public AudioClip audioClipResultOK;
	public AudioClip audioClipResultGood;
	public AudioClip audioClipResultGreat;
	public AudioClip audioClipResultPerfect;

	public AudioClip audioClipGameReplay;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SetText(float resultCash) {
		resultCashText.text = resultCash.ToString();
	}

	void PlayAudioClip(AudioClip clip) {  
		audio.clip = clip;
		audio.Play ();
	}

	AudioClip SelectAudioClip(float resultCash, float startCash) {
		float percentage = resultCash / startCash * 100f; 

		if (percentage >= 80.0f) {
			return audioClipResultPerfect;
		} else if (percentage >= 60.0f) {
			return audioClipResultGreat;
		} else if (percentage >= 40.0f) {
			return audioClipResultGood;
		} else if (percentage >= 20.0f) {
			return audioClipResultOK;
		} else {
			return audioClipResultFail;
		}
	}

	public void ShowResultLayer(float resultCash, float startCash) {
		this.gameObject.SetActive(true);
		SetText (resultCash);
		PlayAudioClip( SelectAudioClip (resultCash, startCash) );
	}

	public void HideResultLayer() {
		this.gameObject.SetActive(false);
	}

	public void OnResultButtonClicked() {
		PlayAudioClip (audioClipGameReplay);
		Application.LoadLevel ("MainScene");
	}
}
