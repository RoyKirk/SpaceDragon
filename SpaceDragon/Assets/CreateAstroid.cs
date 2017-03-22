using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAstroid : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject block;

	// Use this for initialization
	void Start ()
    {
        cubes = GameObject.FindGameObjectsWithTag("CUBE");
        for(int i = 0; i < cubes.Length; i++)
        {
            Instantiate(block, cubes[i].transform, false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
