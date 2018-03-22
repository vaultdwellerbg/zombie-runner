using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool called = false;

	private void Update()
	{
		if (Input.GetButtonDown("CallHeli") && !called)
		{
			called = true;
			print("Helicopter called");
		}
	}
}
