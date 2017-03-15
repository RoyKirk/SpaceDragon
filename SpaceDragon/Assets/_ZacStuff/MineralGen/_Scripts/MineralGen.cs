using UnityEngine;
using System.Collections;

public class MineralGen : MonoBehaviour
{
    GameObject[] planet;
    public GameObject planetCore;
    public float MaxGenDistanceFromCore;

    public int numberOfClusters;
    public int minDistanceBetweenClusters;
    
    public GameObject[] clusterStart;
    int checkCounter;
    int rand;

    public int minClusterResource;
    public int maxClusterResource;
    public int[] currentClusterResources;

    public int minTotalResources;
    public int maxTotalResources;
    public int currentTotalResources;

    GameObject currentStartNode;

    public int CLUSTERSPREAD;
    public int newBlockType;

    // Use this for initialization
    void Start ()
    {
        planet = GameObject.FindGameObjectsWithTag("Block");
        clusterStart = new GameObject[numberOfClusters];
        currentClusterResources = new int[numberOfClusters];
        GenClusterStartPoints();

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void GenClusterStartPoints()
    {
        for(int i = 0; i < numberOfClusters; i++)
        {
            rand = Random.Range(0, planet.Length);
            for (int x = 0; x < clusterStart.Length;x++)
            {
                CHECK(x);

                if(checkCounter == clusterStart.Length)
                {

                    clusterStart[i] = planet[rand];
                    clusterStart[i].GetComponent<fragmentCube>().ChangeType(1);
                }
            }
            checkCounter = 0;
        }
        for(int x = 0; x < clusterStart.Length; x++)
        {
            currentStartNode = clusterStart[x];
            clusterStart[x].GetComponent<fragmentCube>().ChangeType(1);
            ClusterSpread(clusterStart[x], CLUSTERSPREAD);
        }
        CleanupGEN();
        //GenClusterSizes();
    }

    void CHECK(int x)
    {
        float dis = Vector3.Distance(planet[rand].transform.position, planetCore.transform.position);
        if (clusterStart[x] != planet[rand] && dis <= MaxGenDistanceFromCore)
        {
            //
            checkCounter++;
        }
        else// add check distance;
        {
            rand = Random.Range(0, planet.Length);
            CHECK(x);
        }
    }
    
    int iterated;
    int lastDir = -1;

    //calls self until all cluster has been spread;
    void ClusterSpread(GameObject thisObj, int spreadValue)
    {
        
         if (iterated >= 200)
         {
             iterated = 0;
             ClusterSpread(clusterStart[Random.Range(0, clusterStart.Length)], spreadValue);
             Debug.Log("got to iterated");
         }
         if (spreadValue > 0)
         {
             int direction = Random.Range(0, 3);//choose a side to check
            if(direction == lastDir)
            {
                direction = Random.Range(0, 3);
            }
            lastDir = direction;
             switch (direction)
             {
                 case 0://up
                     RaycastSides(thisObj, Vector2.up, spreadValue);
                     break;
                 case 1://down
                     RaycastSides(thisObj, Vector2.down, spreadValue);
                     break;
                 case 2://left
                     RaycastSides(thisObj, Vector2.left, spreadValue);
                     break;
                 case 3://right
                     RaycastSides(thisObj, Vector2.right, spreadValue);
                     break;
             }
         }
        
        
    }

    int RaycastSides(GameObject currentObj, Vector2 direction, int spreadValue)
    {
        currentObj.layer = 2;
        RaycastHit2D hit = Physics2D.Raycast(currentObj.transform.position, direction, 100);
        if(hit != false)
        {
            if (hit.collider.gameObject.tag == "Block")
            {

                float dis = Vector3.Distance(hit.transform.position, planetCore.transform.position);
                if (dis > MaxGenDistanceFromCore)
                {
                    //try again on a different iteration
                    ClusterSpread(currentObj, spreadValue);
                    return 0;
                }
                else
                {
                    //hit something
                    fragmentCube blockType = hit.collider.gameObject.GetComponent<fragmentCube>();
                    if (blockType != null)
                    {
                        if (blockType.typeValue == 0)
                        {
                            //change the blocktype and keep going
                            currentObj.GetComponent<fragmentCube>().ChangeType(newBlockType);
                            spreadValue--;

                            iterated = 0;

                            ClusterSpread(hit.collider.gameObject, spreadValue);
                            return 0;
                        }
                        else
                        {
                            iterated++;
                            ClusterSpread(hit.collider.gameObject, spreadValue);
                            return 0;
                        }
                    }
                }
                
            }
        }
        else
        {
            ClusterSpread(currentObj, spreadValue);
            return 0;
        }
        //currentObj.layer = 0;
        return -1;
    }

    GameObject[] Blocks;

    void CleanupGEN()
    {
        Blocks = GameObject.FindGameObjectsWithTag("Block");
        for(int i = 0; i < Blocks.Length;i++)
        {
            Blocks[i].layer = 0;
        }
    }
}
