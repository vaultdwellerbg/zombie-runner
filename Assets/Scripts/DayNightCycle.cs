using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	public float gameMinutesPerSecond = 1;

	private float anglePerSecond;

	private void Start()
	{
		float anglePerGameMinute = 360f / (60f * 24f);
		anglePerSecond = anglePerGameMinute * gameMinutesPerSecond;
	}

	void Update () {
		float angle = anglePerSecond * Time.deltaTime;
		transform.RotateAround(transform.position, Vector3.forward, angle);
	}
}
