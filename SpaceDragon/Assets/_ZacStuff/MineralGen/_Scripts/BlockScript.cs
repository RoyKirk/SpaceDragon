using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour
{
    public int typeValue = 0;
    public float HP = 1;

    public GameObject particleEffect;
    public GameObject pickUpObj;

    public Material[] blockTypeMats;


    void Update()
    {
        if(HP <= 0)
        {
            Instantiate(pickUpObj, transform.position, Quaternion.identity);
            //give resource to player
            Destroy(gameObject);
        }
    }

    public void ChangeType(int newType)
    {
        //change material and type here
        typeValue = newType;
        switch(newType)
        {
            case 0://grey dirt
                gameObject.GetComponent<Renderer>().material = blockTypeMats[newType];
                break;
            case 1://metal
                gameObject.GetComponent<Renderer>().material = blockTypeMats[newType];
                break;
            case 2://ammo
                gameObject.GetComponent<Renderer>().material = blockTypeMats[newType];
                break;
            case 3://unbreakable
                gameObject.GetComponent<Renderer>().material = blockTypeMats[newType];
                break;
        }
    }

    public void takeDMG(float dmg)
    {
        HP -= dmg;
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        //instantiate a particle effect.
        //drop a pickup when hp <= 0
    }
}
