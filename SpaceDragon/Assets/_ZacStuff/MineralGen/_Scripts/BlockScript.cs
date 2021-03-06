﻿using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour
{
    public int typeValue = 0;
    public float HP = 1;

    public GameObject particleEffect;
    public GameObject[] pickUpObj;

    public Mesh[] DirtMesh;
    public Mesh[] MetalMesh;
    public Mesh[] AmmoMesh;
    public Mesh[] UnbreakableMesh;

    int randMesh = 0;

    bool DROP;
    public float dropDuration = 60;

    void Update()
    {
        if(HP <= 0)
        {
            if(DROP)
            {
                Destroy(Instantiate(pickUpObj[typeValue], transform.position, transform.rotation, transform.parent), dropDuration);
            }
            if(GetComponentInParent<fragmentCube>())
            {
                GetComponentInParent<fragmentCube>().UpdateFragments(this.gameObject);
            }
            else
            {
                GetComponentInParent<AsteroidCube>().UpdateFragments(this.gameObject);
            }
           
            //give resource to player
            Destroy(gameObject);
        }
    }

    //public void UpdateMat(int newType)
    //{
    //    typeValue = newType;
    //    switch (newType)
    //    {
    //        case 0://grey dirt
    //            randMesh = Random.Range(0, DirtMesh.Length);
    //            gameObject.GetComponent<MeshFilter>().mesh = DirtMesh[randMesh];
    //            break;
    //        case 1://metal
    //            randMesh = Random.Range(0, MetalMesh.Length);
    //            gameObject.GetComponent<MeshFilter>().mesh = MetalMesh[0];
    //            break;
    //        case 2://ammo
    //            randMesh = Random.Range(0, AmmoMesh.Length);
    //            gameObject.GetComponent<MeshFilter>().mesh = AmmoMesh[randMesh];
    //            break;
    //        case 3://unbreakable
    //            randMesh = Random.Range(0, UnbreakableMesh.Length);
    //            gameObject.GetComponent<MeshFilter>().mesh = DirtMesh[randMesh];
    //            break;
    //    }
    //}

    public void takeDMG(float dmg, bool drop)
    {
        HP -= dmg;
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        DROP = drop;
        //instantiate a particle effect.
        //drop a pickup when hp <= 0
    }

    public void upgrade()
    {
        GetComponentInParent<fragmentCube>().Upgrade();
    }
}
