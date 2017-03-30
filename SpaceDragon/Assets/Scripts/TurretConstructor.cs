using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConstructor : MonoBehaviour
{

    public GameObject TurretPrefab;

    public float bulletSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            //Upgrade the block
            collision.gameObject.GetComponent<fragmentCube>().Upgrade();
            Destroy(this.gameObject);
            //if (collision.gameObject.GetComponent<fragmentCube>().typeValue <= 2)
            //{
            //    collision.gameObject.GetComponent<fragmentCube>().shot = true;
            //}
            //else
            //{
            //    //Instantiate(shootParticle, transform.position, Quaternion.identity);
            //   // TakeDMG(HP);
            //}
        }
        else if (collision.gameObject.tag == "Fragment")
        {
            collision.gameObject.GetComponent<BlockScript>().upgrade();
            Destroy(this.gameObject);
            //destroy the fragments and create a block connecting to blocks.

            //dmg block and take dmg
            //collision.gameObject.GetComponent<BlockScript>().takeDMG(1, true);
            //TakeDMG(1);
        }
    }
}
