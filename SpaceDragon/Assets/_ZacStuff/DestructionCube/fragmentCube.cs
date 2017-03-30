using UnityEngine;
using System.Collections;

public class fragmentCube : MonoBehaviour
{
    //public bool shot;
    public GameObject[] fragmentObj;
    public int fragmentPieces;

    PlayerMovement PM;

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

    Tier[] blockTiers;
    int numberOfTiers = 4;

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
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        //set up tiers
        blockTiers = new Tier[numberOfTiers];
        blockTiers[0].SetupTier(9, DirtMesh[0]);
        blockTiers[1].SetupTier(3, MetalMesh[0]);


        hp = fragmentObj.Length;
        //blockTiers[1].SetupTier(3, )

        //iterationVector = new Vector3(transform.position.x - (transform.localScale.x / 2) + fragmentObj.transform.localScale.x / fragmentPieces / 2, transform.position.y - (transform.localScale.y / 2) + fragmentObj.transform.localScale.y / fragmentPieces / 2, transform.position.z);// - (transform.localScale / 2) + fragmentObj.transform.localScale / 2);
        //iterationScale = fragmentObj.transform.localScale.x;

        //Fragment();
    }

    bool fragmented;
	// Update is called once per frame
	void LateUpdate ()
    {
        if(currentTier == 0)
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
            Downgrade();
        }
    }
    

    void Fragment()
    {
        for(int x = 0; x < fragmentObj.Length; x++)//fragmentPieces; x++)
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

    public void Upgrade()
    {
        if(currentTier == 0)
        {
            if (fragmentObj.Length == 9)//max size of how many fragments in cube
            {
                //check if we have enough resources
                if(PM.blockCount >= 3)
                {
                    //yes-> upgrade to next tier
                    UpdateTier(1);
                }
                else
                {
                    //no -> error we dont have the resources
                }
            }
            else
            {
                //check if player has enough to repair
                if (PM.blockCount >= (9 - fragmentObj.Length))
                {
                    //yes-> Destroy this and replace with new chunk
                    GetComponentInParent<CreatePlanet>().ReplaceChunk(this.gameObject);
                }
                else
                {
                    //no -> error we dont have enough dirt
                }
            }
        }
        else if(currentTier == 1)
        {
            if (hp == blockTiers[currentTier].MaxHp)
            {
                //check if we have enough resources
                if (PM.metalCount >= 1)
                {
                    //yes-> upgrade to next tier
                    UpdateTier(1);
                }
                else
                {
                    //no -> error we dont have the resources
                }
            }
            else
            {
                //check if player has enough to repair
                if (PM.blockCount >= (hp - blockTiers[currentTier].MaxHp))
                {
                    //yes-> set current Hp to max
                    hp = blockTiers[currentTier].MaxHp;
                }
                else
                {
                    //no -> error we dont have enough dirt
                }
            }
        }
        else if(currentTier <= numberOfTiers)
        {
            if(hp == blockTiers[currentTier].MaxHp)
            {
                //check if we have enough resources
                if(currentTier == blockTiers.Length)
                {
                    //error already max tier
                }
                else
                {
                    if (PM.metalCount >= 1)
                    {
                        //yes-> upgrade to next tier
                        UpdateTier(1);
                    }
                    else
                    {
                        //no -> error we dont have the resources
                    }
                }
               
            }
            else
            {
                //check if player has enough to repair
                if (PM.metalCount >= 1)
                {
                    //yes-> set current Hp to max
                    hp = blockTiers[currentTier].MaxHp;
                }
                else
                {
                    //no -> error we dont have enough dirt
                }
            }
        }
        

        
    }

    void Downgrade()
    {
        //call this when hp == 0
        if(currentTier == 0)
        {
            Destroy(gameObject);
        }

        UpdateTier(-1);
        //go down a tier and update new stats / material.
    }

    void UpdateTier(int increment)
    {
        //set currentStats to be the current Tier
        currentTier += increment;

        hp = blockTiers[currentTier].MaxHp;
        gameObject.GetComponent<MeshFilter>().mesh = blockTiers[currentTier].blockMesh;


        if(currentTier == 0)
        {
            //enable childed fragments.
            for(int i = 0; i < fragmentObj.Length;i++)
            {
                fragmentObj[i].SetActive(true);
            }
        }
        if (currentTier == 1)
        {
            //disable childed fragments.
            for (int i = 0; i < fragmentObj.Length; i++)
            {
                fragmentObj[i].SetActive(false);
            }
        }

    }


    //changes the array size of the fragmentObj array (the blocks health), to match how many fragments their are.
    GameObject[] temp;
    int iteration = 0;

    public void UpdateFragments(GameObject exclude)
    {
        iteration = 0;
        temp = new GameObject[fragmentObj.Length - 1];
        for(int i = 0; i < fragmentObj.Length; i++)
        {
            if(fragmentObj[i] != exclude)
            {
                temp[iteration] = fragmentObj[i];
                iteration++;
            }
        }

        fragmentObj = new GameObject[temp.Length];
        for(int y = 0; y < temp.Length;y++)
        {
            fragmentObj[y] = temp[y];
        }
    }
}
