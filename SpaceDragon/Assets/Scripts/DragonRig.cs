using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRig : MonoBehaviour
{
    public DragonAttack playerAttack;
    public Transform player;

    public DragonAttack planetAttack;
    public Transform planet;

	// Use this for initialization
	void Start ()
    {
		
	}

    public void AssignReferences()
    {
        playerAttack.target = player;
        planetAttack.target = planet;
    }
}
