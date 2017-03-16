using UnityEngine;
using System.Collections;

public class DragonAttack : MonoBehaviour 
{
	public GameObject Fireball;
	public Transform dragonPivot;

	public float cooldown;
	float remainingCooldown;

	public float duration;
	float remainingDuration;

	public float frequency;
	float delay;

	// Use this for initialization
	void Start () 
	{
		remainingCooldown = cooldown;
		remainingDuration = duration;
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		remainingCooldown -= Time.deltaTime;

		if (remainingCooldown <= 0)
		{
			Attack ();
		}
	}

	void Attack()
	{
		remainingDuration -= Time.deltaTime;
		delay -= Time.deltaTime;

		if (delay <= 0)
		{
			delay = frequency;
			GameObject currentFireball = Instantiate (Fireball, transform.position, dragonPivot.rotation) as GameObject;
			currentFireball.GetComponent<Fireball> ().dragonPivot = dragonPivot;
		}

		if (remainingDuration <= 0) 
		{
			remainingCooldown = cooldown;
			remainingDuration = duration;
		}
	}
}
