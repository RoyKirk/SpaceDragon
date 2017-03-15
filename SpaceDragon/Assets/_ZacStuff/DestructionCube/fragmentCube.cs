using UnityEngine;
using System.Collections;

public class fragmentCube : MonoBehaviour
{
    public bool shot;
    public GameObject fragmentObj;
    public int fragmentPieces;

    Vector3 iterationVector;
    float iterationScale;
    float hp;

    public Mesh[] DirtMesh;
    public Mesh[] MetalMesh;
    public Mesh[] AmmoMesh;
    public Mesh[] UnbreakableMesh;
    int randMesh = 0;

    public int typeValue = 0;

    public bool change;

    // Use this for initialization
    void Start ()
    {
        iterationVector = new Vector3(transform.position.x - (transform.localScale.x / 2) + fragmentObj.transform.localScale.x / fragmentPieces / 2, transform.position.y - (transform.localScale.y / 2) + fragmentObj.transform.localScale.y / fragmentPieces / 2, transform.position.z);// - (transform.localScale / 2) + fragmentObj.transform.localScale / 2);
        iterationScale = fragmentObj.transform.localScale.x;

        //Fragment();
    }
    
	// Update is called once per frame
	void LateUpdate ()
    {
        if(change == true)
        {
            UpdateMat(typeValue);
        }
        if (shot)
        {
            shot = false;
            Fragment();
        }
	}

    GameObject frag;

    void Fragment()
    {
        for(int x = 0; x < fragmentPieces; x++)
        {
            for(int y = 0; y < fragmentPieces;y++)
            {
                frag = Instantiate(fragmentObj) as GameObject;
               // frag.transform.localScale = gameObject.transform.localScale;
                frag.transform.localScale = new Vector3(frag.transform.localScale.x / fragmentPieces, frag.transform.localScale.y / fragmentPieces, frag.transform.localScale.z);
                frag.transform.position = new Vector3(iterationVector.x + (fragmentObj.transform.localScale.x/fragmentPieces * x), iterationVector.y + (fragmentObj.transform.localScale.y/fragmentPieces * y), iterationVector.z);
                Quaternion newRot = Quaternion.identity;
                newRot.eulerAngles  = new Vector3(0, 180, 0);
                frag.transform.rotation = newRot;
                frag.GetComponent<BlockScript>().UpdateMat(typeValue);
                
            }
        }
        Destroy(gameObject);
        //GetComponent<MeshRenderer>().enabled = false;
        //Instantiate(fragmentObj, (transform.position - (transform.localScale / 2) + fragmentObj.transform.localScale/2), Quaternion.identity);
    }


    

    

    public void ChangeType(int newType)
    {
        //change material and type here
        typeValue = newType;
        change = true;
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
        change = false;
    }
}
