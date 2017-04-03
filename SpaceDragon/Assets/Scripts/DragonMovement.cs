using UnityEngine;
using System.Collections;

public class DragonMovement : MonoBehaviour 
{
    public Transform playerPos;

	public GameObject dragonPrefab;
	GameObject dragonClone;

	public Vector3 spawnPos;

	Vector3 velocity;
	public float moveSpeed;
	public float rotateSpeed;
	public float orbitDistanceFromCore;

	public float spawnTimer;
	float spawnCooldown;
	bool isSpawned;
	bool isLeaving;

	public float dragonDuration;
	float dragonLifetime;

	public int startingHealth;
	public float healthMultiplier;
	[HideInInspector] public int maxHealth;


	// Use this for initialization
	void Start () 
	{
		spawnCooldown = spawnTimer;
		dragonLifetime = dragonDuration;
		velocity.x = 1;
		maxHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSpawned == false) 
		{
			spawnCooldown -= Time.deltaTime;

			if (spawnCooldown <= 0) 
			{
				SpawnDragon ();
			}
		}

		if (isSpawned == true) 
		{
			MoveDragon ();
			dragonLifetime -= Time.deltaTime;

			if (dragonLifetime <= 0)
			{
				isLeaving = true;
			}
		}
	}

	void SpawnDragon()
	{
		dragonClone = Instantiate (dragonPrefab, this.transform, false) as GameObject;
		dragonClone.transform.position = spawnPos;
        dragonClone.GetComponent<DragonRig>().player = playerPos;
        dragonClone.GetComponent<DragonRig>().planet = this.transform;
        dragonClone.GetComponent<DragonRig>().AssignReferences();
        dragonLifetime = dragonDuration;
		isSpawned = true;
		isLeaving = false;
	}

	void MoveDragon()
	{
		if (isLeaving)
		{
			dragonClone.transform.localPosition += velocity * moveSpeed * Time.deltaTime;

			if (Vector3.Distance (this.transform.position, dragonClone.transform.position) > orbitDistanceFromCore * 2) 
			{
				DespawnDragon ();
			}
		}

		if (dragonClone != null && Vector3.Distance (this.transform.position, dragonClone.transform.position) > orbitDistanceFromCore) 
		{
			dragonClone.transform.position += velocity * moveSpeed * Time.deltaTime;
		}

		if (dragonClone != null && Vector3.Distance (this.transform.position, dragonClone.transform.position) <= orbitDistanceFromCore) 
		{
			transform.Rotate (Vector3.forward * -1 * rotateSpeed * Time.deltaTime);
		}
	}

	public void DespawnDragon()
	{
		maxHealth = (int)(maxHealth * healthMultiplier);
		Destroy (dragonClone.gameObject);
		spawnCooldown = spawnTimer;
		isSpawned = false;

		transform.rotation = Quaternion.Euler(Vector3.zero);
	}
}
