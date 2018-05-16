using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Zombie : MonoBehaviour {

	public AudioClip[] grunts;
	public AudioClip attackSound;

	private Animator animator;
	private AudioSource audioSource;
	private float originalAnimSpeed;
	private ThirdPersonCharacter tps;

	private void Start()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		tps = GetComponent<ThirdPersonCharacter>();
		InvokeRepeating("Grunt", 0f, 3f);
	}

	private void Grunt()
	{
		audioSource.Stop();
		audioSource.clip = grunts[Random.Range(0, grunts.Length)];
		audioSource.Play();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Attack();
		}
	}

	private void Attack()
	{
		originalAnimSpeed = tps.m_AnimSpeedMultiplier;
		tps.m_AnimSpeedMultiplier = 1f;
		animator.SetBool("isAttacking", true);
		CancelInvoke("Grunt");
		PlayAttackingSound();
	}

	private void PlayAttackingSound()
	{
		audioSource.Stop();
		audioSource.clip = attackSound;
		audioSource.loop = true;
		audioSource.Play();
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Walk();
		}
	}

	private void Walk()
	{
		tps.m_AnimSpeedMultiplier = originalAnimSpeed;
		animator.SetBool("isAttacking", false);
		audioSource.loop = false;
		InvokeRepeating("Grunt", 0f, 3f);
	}
}
