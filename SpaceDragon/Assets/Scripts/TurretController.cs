using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject Dragon;

    fragmentCube TierScript;

    public GameObject projectile;

    GameObject P;
    float Pspeed;

    bool lineOfSight;

    float shootDelay;
    float currentShootDelay;


	// Use this for initialization
	void Start ()
    {
        TierScript = GetComponentInParent<fragmentCube>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(TierScript.currentTier == 3)
        {
            if (Dragon == null)
            {
                Dragon = GameObject.FindGameObjectWithTag("Dragon");
            }

            RaycastDragon();
            Fire();
        }
        
	}

    void RaycastDragon()
    {
        if(Dragon != null)
        {
            transform.LookAt(Dragon.transform);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Dragon.transform.position);

            if(hit.distance >= (Vector2.Distance(transform.position, Dragon.transform.position) - 5f))
            {
                lineOfSight = true;
            }
            else
            {
                lineOfSight = false;
            }
            //raycast towards the dragons position, if distance (within margin) == distance between turret and dragon. FIRE!
        }
    }

    void Fire()
    {
        currentShootDelay -= Time.deltaTime;

        if(lineOfSight)
        {
            if(currentShootDelay <= 0)
            {
                P = Instantiate(projectile, transform.position, transform.localRotation) as GameObject;
                P.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Pspeed);
                currentShootDelay = shootDelay;
            }
        }
        else
        {

        }
        //check delay, shoot, reset delay

        //else
        //reset delay. do nothing
    }
}
