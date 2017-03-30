using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanet : MonoBehaviour
{
    public GameObject Chunk;
    

	// Use this for initialization
	void Start ()
    {
        Instantiate(Chunk, transform.position, transform.rotation, gameObject.transform);
        GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ReplaceChunk(GameObject childObj)
    {
        //destroy old chunk and create a new one.
        Destroy(childObj);
        Instantiate(Chunk, transform.position, transform.rotation, gameObject.transform);
    }
}
