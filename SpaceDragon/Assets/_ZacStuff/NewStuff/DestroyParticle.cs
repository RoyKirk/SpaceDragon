using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {
    public float Lifetime = 1;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, Lifetime);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
