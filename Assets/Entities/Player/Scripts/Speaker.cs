using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {

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
