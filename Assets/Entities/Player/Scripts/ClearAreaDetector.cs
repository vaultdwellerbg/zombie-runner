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
		if (IsClearZoneFound())
		{
			clearZoneFound = true;
			SendMessageUpwards("OnFindClearArea");
			audioSource.Play();
		}
	}

	private bool IsClearZoneFound()
	{
		return !clearZoneFound
			&& Time.timeSinceLevelLoad - timeOfLastTrigger > 1f
			&& Time.timeSinceLevelLoad > 10f;
	}

	private void OnTriggerStay(Collider other)
	{
		timeOfLastTrigger = Time.timeSinceLevelLoad;
	}
}
