using UnityEngine;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;
	public AudioClip landingAreaFound;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		Invoke("WhatHappened", 1);
	}

	void WhatHappened()
	{
		audioSource.clip = whatHappened;
		audioSource.Play();
	}

	void OnClearAreaFound()
	{
		audioSource.clip = landingAreaFound;
		audioSource.Play();
		Invoke("CallHeli", landingAreaFound.length + 1f);
	}

	void CallHeli()
	{
		SendMessageUpwards("OnMakeInitialHeliCall");
	}
}
