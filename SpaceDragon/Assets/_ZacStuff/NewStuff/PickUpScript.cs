using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    GameObject Player;

    public int TypeValue;

    public float speed;

    bool seek;

    public float SeekDistance = 2;
    public float PickUpDistance = 0.2f;
	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
	    if(distance <= SeekDistance)
        {
            //seek out the player
            seek = true;
        }
        if(distance <= PickUpDistance)
        {
            //player picks up resource
            switch(TypeValue)
            {
                case 0:
                    Player.GetComponent<PlayerMovement>().blockCount += 1;
                    break;
                case 1:
                    Player.GetComponent<PlayerMovement>().metalCount += 1;
                    break;
                case 2:
                    //Player.GetComponent<PlayerMovement>().blockCount += 1;
                    break;
                case 3:
                    //Player.GetComponent<PlayerMovement>().blockCount += 1;
                    break;
                default:
                    //Player.GetComponent<PlayerMovement>().blockCount += 1;
                    break;
            }
            
            Destroy(gameObject);
        }
        if(seek)
        {
            transform.LookAt(Player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FireBall")
        {
            Destroy(gameObject);
        }
    }
}
