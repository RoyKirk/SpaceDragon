using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour 
{
	public float lifespan;
	public float speed;

    int health;
    public int minHealth;
    public int maxHealth;

    public Transform target;
	Vector3 destination;

	//public Vector2 target;

	// Use this for initialization
	void Start () 
	{
        health = Random.Range(minHealth, maxHealth);
		Destroy (this.gameObject, lifespan);
		destination = target.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (destination);
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
	}

	void RaycastBlock()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1.2f);
		if (hit != false)
		{
			if (hit.collider.tag == "Block")
			{
                //trigger shot condition to fragment
                hit.collider.gameObject.GetComponent<fragmentCube>().TakeDamage(1);// = true;
			}
			else if (hit.collider.tag == "Fragment")
			{
				//dmg block and take dmg
				hit.collider.gameObject.GetComponent<BlockScript>().takeDMG(1,false);
				TakeDamage(1);
			}
		}
	}

	void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if (collision.gameObject.GetComponent<fragmentCube>().typeValue <= 2)
            {
                collision.gameObject.GetComponent<fragmentCube>().TakeDamage(1);// = true;
            }
            else
            {
                TakeDamage(1);
            }
        }
        else if (collision.gameObject.tag == "Fragment")
        {
            //dmg block and take dmg
            if (collision.gameObject.GetComponent<BlockScript>().typeValue <= 2)
            {
                collision.gameObject.GetComponent<BlockScript>().takeDMG(1, false);
                TakeDamage(1);
            }
            else
            {
                TakeDamage(1);
            }
        }
    }
}
