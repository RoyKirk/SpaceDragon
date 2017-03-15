using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour
{
    public int typeValue = 0;
    public float HP = 1;

    public GameObject particleEffect;
    public GameObject pickUpObj;

    public Mesh[] DirtMesh;
    public Mesh[] MetalMesh;
    public Mesh[] AmmoMesh;
    public Mesh[] UnbreakableMesh;

    int randMesh = 0;

    void Update()
    {
        if(HP <= 0)
        {
            Instantiate(pickUpObj, transform.position, Quaternion.identity);
            //give resource to player
            Destroy(gameObject);
        }
    }

    public void UpdateMat(int newType)
    {
        typeValue = newType;
        switch (newType)
        {
            case 0://grey dirt
                randMesh = Random.Range(0, DirtMesh.Length);
                gameObject.GetComponent<MeshFilter>().mesh = DirtMesh[randMesh];
                break;
            case 1://metal
                randMesh = Random.Range(0, MetalMesh.Length);
                gameObject.GetComponent<MeshFilter>().mesh = MetalMesh[0];
                break;
            case 2://ammo
                randMesh = Random.Range(0, AmmoMesh.Length);
                gameObject.GetComponent<MeshFilter>().mesh = AmmoMesh[randMesh];
                break;
            case 3://unbreakable
                randMesh = Random.Range(0, UnbreakableMesh.Length);
                gameObject.GetComponent<MeshFilter>().mesh = UnbreakableMesh[randMesh];
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
