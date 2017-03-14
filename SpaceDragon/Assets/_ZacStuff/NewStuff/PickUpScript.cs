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
            Player.GetComponent<PlayerMovement>().blockCount += 1;
            Destroy(gameObject);
        }
        if(seek)
        {
            transform.LookAt(Player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
	}
}
