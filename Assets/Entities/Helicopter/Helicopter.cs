using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Rigidbody rigidbody;
	private AudioSource audioSource;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	public void Call()
	{
		if (!called)
		{
			called = true;
			audioSource.Play();
			rigidbody.velocity = new Vector3(0, 0, 50f);
		}
	}
}
