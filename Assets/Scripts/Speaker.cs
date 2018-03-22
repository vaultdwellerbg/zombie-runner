using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (Input.GetButtonDown("CallHeli"))
		{
			audioSource.Play();
		}
	}
}
