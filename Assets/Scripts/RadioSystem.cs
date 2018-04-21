using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnMakeInitialHeliCall()
	{
		PlayClip(initialHeliCall);
		Invoke("ReplyToCall", initialHeliCall.length + 1f);
	}

	void PlayClip(AudioClip clip)
	{
		audioSource.clip = clip;
		audioSource.Play();
	}

	void ReplyToCall()
	{
		PlayClip(initialCallReply);
		BroadcastMessage("OnDispatchHelicopter");
	}
}
