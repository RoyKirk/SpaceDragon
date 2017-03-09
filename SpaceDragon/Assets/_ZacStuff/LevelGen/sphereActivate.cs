using UnityEngine;
using System.Collections;

public class sphereActivate : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
