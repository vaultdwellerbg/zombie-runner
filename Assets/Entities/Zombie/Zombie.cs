using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			animator.SetBool("isAttacking", true);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			animator.SetBool("isAttacking", false);
		}
	}
}
