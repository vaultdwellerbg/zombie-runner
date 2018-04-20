using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAreaDetector : MonoBehaviour {

	private float timeOfLastTrigger;
	private bool clearZoneFound = false;
	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (!clearZoneFound && Time.timeSinceLevelLoad - timeOfLastTrigger > 1f)
		{
			clearZoneFound = true;
			SendMessageUpwards("OnFindClearArea");
			audioSource.Play();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		timeOfLastTrigger = Time.timeSinceLevelLoad;
	}
}
