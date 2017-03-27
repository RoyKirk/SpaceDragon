using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRig : MonoBehaviour
{
	public DragonMovement dragonPivot;

	public DragonAttack plasmaAttack;
    public Transform player;

	public DragonAttack devestateAttack;
    public DragonAttack starfallAttack;
    public Transform planet;

	int health;

	// Use this for initialization
	void Start ()
    {
		
	}

    public void AssignReferences()
	{
		plasmaAttack.target = player;
		devestateAttack.target = planet;
		starfallAttack.target = planet;
    }

	public void TakeDamage(int damage)
	{
		
	}
}
