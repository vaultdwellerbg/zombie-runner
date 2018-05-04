using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAreaDetector : MonoBehaviour {

	private float timeOfLastTrigger;
	private bool clearZoneFound = false;
	private int collidersInArea = 0;
	
	void Update () {
		if (clearZoneFound) return;

		if (collidersInArea > 0)
		{
			timeOfLastTrigger = Time.timeSinceLevelLoad;
		}
		else if (IsClearZoneFound())
		{
			clearZoneFound = true;
			SendMessageUpwards("OnFindClearArea");
		}
	}

	private bool IsClearZoneFound()
	{
		return Time.timeSinceLevelLoad - timeOfLastTrigger > 3f
			&& Time.timeSinceLevelLoad > 10f;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Terrain")
		{
			collidersInArea++;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.name == "Terrain")
		{
			collidersInArea--;
		}
	}
}
