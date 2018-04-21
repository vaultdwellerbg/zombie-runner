using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Rigidbody rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void OnDispatchHelicopter()
	{
		if (!called)
		{
			called = true;
			rigidbody.velocity = new Vector3(0, 0, 50f);
		}
	}
}
