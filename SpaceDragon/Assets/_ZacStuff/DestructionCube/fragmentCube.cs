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

    public int typeValue = 0;

    public bool change;

    // Use this for initialization
    void Start ()
    {
        iterationVector = (transform.position - (transform.localScale / 2) + fragmentObj.transform.localScale / 2);
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
                frag = Instantiate(fragmentObj, new Vector3(iterationVector.x + (x*2), iterationVector.y + (y/5), iterationVector.z), Quaternion.identity) as GameObject;
                frag.GetComponent<BlockScript>().ChangeType(typeValue);
            }
        }
        Destroy(gameObject);
        //GetComponent<MeshRenderer>().enabled = false;
        //Instantiate(fragmentObj, (transform.position - (transform.localScale / 2) + fragmentObj.transform.localScale/2), Quaternion.identity);
    }


    

    public Material[] blockTypeMats;

    public void ChangeType(int newType)
    {
        //change material and type here
        typeValue = newType;
        change = true;
    }

    void UpdateMat(int newType)
    {
        switch (newType)
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
        change = false;
    }
}
