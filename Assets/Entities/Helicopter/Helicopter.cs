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

	public void Call()
	{
		if (!called)
		{
			called = true;
			print("Helicopter called");
			rigidbody.velocity = new Vector3(0, 0, 50f);
		}
	}
}
