using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAreaDetector : MonoBehaviour {

	private float timeOfLastTrigger;
	private bool clearZoneFound = false;
	
	void Update () {
		if (IsClearZoneFound())
		{
			clearZoneFound = true;
			SendMessageUpwards("OnFindClearArea");
		}
	}

	private bool IsClearZoneFound()
	{
		return !clearZoneFound
			&& Time.timeSinceLevelLoad - timeOfLastTrigger > 1f
			&& Time.timeSinceLevelLoad > 10f;
	}

	private void OnTriggerStay(Collider collider)
	{
		if (collider.tag != "Player")
		{
			timeOfLastTrigger = Time.timeSinceLevelLoad;
		}
	}
}
