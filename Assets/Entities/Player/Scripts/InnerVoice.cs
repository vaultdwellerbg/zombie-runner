using UnityEngine;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void WhatHappened()
	{
		audioSource.clip = whatHappened;
		audioSource.Play();
	}
	

}
