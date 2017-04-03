using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCollider : MonoBehaviour 
{
	public DragonRig myRig;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.rotation = Quaternion.Euler (Vector3.zero);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 9) //bullet is currently layer 9
		{
			//collision.gameObject.GetComponent<BulletBehavoiur> ().damage;
			myRig.TakeDamage (1);
			Debug.Log ("hit");
		}
	}
}
