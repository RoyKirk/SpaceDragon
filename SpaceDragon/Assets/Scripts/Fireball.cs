using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour 
{
	public float lifespan;
	public float speed;

	public int health;

	public Transform dragonPivot;

	Vector2 velocity;

	// Use this for initialization
	void Start () 
	{
		Destroy (this, lifespan);
		transform.LookAt (dragonPivot);
		velocity.y = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);
		//transform.localPosition += velocity * speed * Time.deltaTime;
	}

	void RaycastBlock()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.2f);
		if (hit != false)
		{
			if (hit.collider.tag == "Block")
			{
				//trigger shot condition to fragment
				hit.collider.gameObject.GetComponent<fragmentCube>().shot = true;
			}
			else if (hit.collider.tag == "Fragment")
			{
				//dmg block and take dmg
				hit.collider.gameObject.GetComponent<BlockScript>().takeDMG(1);
				TakeDamage(1);
			}
		}
	}

	void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0) 
		{
			Destroy (this);
		}
	}
}
