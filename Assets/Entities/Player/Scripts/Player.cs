using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints;
	public GameObject landingAreaPrefab;

	private bool respawn = false;
	private Vector3[] spawnPoints;
	private Vector3 flareLocation;
	private Quaternion flareRotation;
	private CharacterController characterController;

	void Start () {
		FindSpawnPoints();
		characterController = GetComponent<CharacterController>();
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
		StoreFlarePositioningData();
		BroadcastMessage("OnClearAreaFound");
		Invoke("DropFlare", 3f);
	}

	private void StoreFlarePositioningData()
	{
		flareLocation = GetFlareLocation();
		flareRotation = transform.rotation;
	}

	private Vector3 GetFlareLocation()
	{
		Vector3 playerPosition = transform.position;
		float playerFeetY = playerPosition.y - characterController.height / 2;
		return new Vector3(playerPosition.x, playerFeetY, playerPosition.z);
	}

	void DropFlare()
	{
		GameObject.Instantiate(landingAreaPrefab, flareLocation, flareRotation);
	}
}
