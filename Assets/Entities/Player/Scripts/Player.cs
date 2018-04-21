using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints;

	private bool respawn = false;
	private Vector3[] spawnPoints;

	void Start () {
		FindSpawnPoints();
	}

	private void FindSpawnPoints()
	{
		int pointsCount = playerSpawnPoints.childCount;
		spawnPoints = new Vector3[pointsCount];
		for (int i = 0; i < pointsCount; i++)
		{
			spawnPoints[i] = playerSpawnPoints.GetChild(i).position;
		}
	}

	private void Update()
	{
		if (respawn)
		{
			Respawn();
			respawn = false;
		}
	}

	private void Respawn() {
		Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		transform.position = randomSpawnPoint;
	}

	void OnFindClearArea()
	{
		BroadcastMessage("OnClearAreaFound");
		Invoke("DropFlare", 3f);
	}

	void DropFlare()
	{
		Debug.Log("Flare dropped");
	}
}
