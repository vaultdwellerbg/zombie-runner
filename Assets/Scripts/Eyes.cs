using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

	public float zoomRate = 1.5f;

	private Camera eyes;
	private float defaultFOV;

	void Start () {
		eyes = GetComponent<Camera>();
		defaultFOV = eyes.fieldOfView;
	}
	
	void Update () {
		if (Input.GetButtonDown("Zoom"))
		{
			eyes.fieldOfView = defaultFOV / zoomRate;
		}
		if (Input.GetButtonUp("Zoom"))
		{
			eyes.fieldOfView = defaultFOV;
		}
	}
}
