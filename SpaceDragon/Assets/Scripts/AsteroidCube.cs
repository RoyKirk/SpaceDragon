using UnityEngine;
using System.Collections;

public class AsteroidCube : MonoBehaviour
{
    //public bool shot;
    public GameObject[] fragmentObj;
    public int fragmentPieces;


    //Vector3 iterationVector;
    //float iterationScale;
    public float hp = 9;
    int currentTier = 0;


    struct Tier
    {
        public float MaxHp;
        public Mesh blockMesh;

        public void SetupTier(float maxHp, Mesh mesh)
        {
            MaxHp = maxHp;
            blockMesh = mesh;
            //repairCost
            //upgradeCost

        }
    };

    public Mesh[] DirtMesh;
    public Mesh[] MetalMesh;
    public Mesh[] AmmoMesh;
    public Mesh[] UnbreakableMesh;
    int randMesh = 0;

    public int typeValue = 0;

    public bool change;

    // Use this for initialization
    void Start()
    {



        hp = fragmentObj.Length;
        GetComponent<BoxCollider2D>().enabled = false;
        //blockTiers[1].SetupTier(3, )

        //iterationVector = new Vector3(transform.position.x - (transform.localScale.x / 2) + fragmentObj.transform.localScale.x / fragmentPieces / 2, transform.position.y - (transform.localScale.y / 2) + fragmentObj.transform.localScale.y / fragmentPieces / 2, transform.position.z);// - (transform.localScale / 2) + fragmentObj.transform.localScale / 2);
        //iterationScale = fragmentObj.transform.localScale.x;

        //Fragment();
    }

    bool fragmented;
    // Update is called once per frame
    void LateUpdate()
    {
        if (currentTier == 0)
        {
            hp = fragmentObj.Length;
            if (change == true)
            {
                UpdateMat(typeValue);
            }
            if (hp <= 8 && fragmented == false)
            {
                Fragment();
                fragmented = true;
            }
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Fragment()
    {
        for (int x = 0; x < fragmentObj.Length; x++)//fragmentPieces; x++)
        {
            //for(int y = 0; y < fragmentPieces;y++)
            //{
            //iterationVector = new Vector3(transform.position.x - (transform.localScale.x / 2) + fragmentObj.transform.localScale.x / fragmentPieces / 2, transform.position.y - (transform.localScale.y / 2) + fragmentObj.transform.localScale.y / fragmentPieces / 2, transform.position.z);// - (transform.localScale / 2) + fragmentObj.transform.localScale / 2);

            //frag = Instantiate(fragmentObj, this.transform.parent, false) as GameObject;
            // frag.transform.localScale = gameObject.transform.localScale;
            //frag.transform.localScale = new Vector3(frag.transform.localScale.x / fragmentPieces, frag.transform.localScale.y / fragmentPieces, frag.transform.localScale.z);
            //frag.transform.position = new Vector3(iterationVector.x + (fragmentObj.transform.localScale.x/fragmentPieces * x), iterationVector.y + (fragmentObj.transform.localScale.y/fragmentPieces * y), iterationVector.z);
            // Quaternion newRot = Quaternion.identity;
            //newRot.eulerAngles  = new Vector3(0, 180, 0);
            //frag.transform.rotation = transform.rotation;

            fragmentObj[x].GetComponent<MeshRenderer>().enabled = true;
            //fragmentObj[x].GetComponent<BlockScript>().UpdateMat(typeValue);

            //}
        }
        GetComponent<MeshRenderer>().enabled = false;
        //Destroy(gameObject);
        //GetComponent<MeshRenderer>().enabled = false;
        //Instantiate(fragmentObj, (transform.position - (transform.localScale / 2) + fragmentObj.transform.localScale/2), Quaternion.identity);
    }


    public void TakeDamage(int DMG)
    {
        //take a dmg from fireball
        hp -= DMG;
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

    //changes the array size of the fragmentObj array (the blocks health), to match how many fragments their are.
    GameObject[] temp;
    int iteration = 0;

    public void UpdateFragments(GameObject exclude)
    {
        iteration = 0;
        temp = new GameObject[fragmentObj.Length - 1];
        for (int i = 0; i < fragmentObj.Length; i++)
        {
            if (fragmentObj[i] != exclude)
            {
                temp[iteration] = fragmentObj[i];
                iteration++;
            }
        }

        fragmentObj = new GameObject[temp.Length];
        for (int y = 0; y < temp.Length; y++)
        {
            fragmentObj[y] = temp[y];
        }
    }
}

    