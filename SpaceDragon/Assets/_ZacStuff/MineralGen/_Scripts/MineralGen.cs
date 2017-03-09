using UnityEngine;
using System.Collections;

public class MineralGen : MonoBehaviour
{
    public GameObject[] planet;

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
                    clusterStart[i].GetComponent<fragmentCube>().typeValue = 1;
                }
            }
            checkCounter = 0;
        }
        for(int x = 0; x < clusterStart.Length; x++)
        {
            currentStartNode = clusterStart[x];
            clusterStart[x].GetComponent<fragmentCube>().typeValue = 1;
            ClusterSpread(clusterStart[x], 3);
        }
        //GenClusterSizes();
    }

    void CHECK(int x)
    {
        if (clusterStart[x] != planet[rand])
        {
            //
            checkCounter++;
        }
        else// add check distance;
        {
            Debug.Log("hit a duplicate");
            rand = Random.Range(0, planet.Length);
            CHECK(x);
        }
    }

    void GenClusterSizes()//re-write this so it works and makes sense, we need it to divide the total between each cluster randomly within their min max limits.
    {
        //currentTotalResources = Random.Range(minTotalResources, maxTotalResources);
        //
        //for(int i = 0; i < currentClusterResources.Length;i++)
        //{
        //    currentClusterResources[i] = Random.Range(minClusterResource, maxClusterResource);
        //    currentTotalResources -= currentClusterResources[i];
        //    if(i == currentClusterResources.Length - 1)
        //    {
        //        if(currentTotalResources <= maxClusterResource && currentTotalResources >= minClusterResource)
        //        {
        //            currentClusterResources[i] = currentTotalResources;
        //        }
        //        else
        //        {
        //            Debug.Log("it doesnt fit");
        //        }
        //    }
        //}
    }

    //int lastDir;

    
    int iterated;

    //calls self until all cluster has been spread;
    void ClusterSpread(GameObject thisObj, int spreadValue)
    {
        
        if (iterated >= 200)
        {
            iterated = 0;
            ClusterSpread(clusterStart[Random.Range(0, clusterStart.Length)], spreadValue);
            
        }
        if (spreadValue > 0)//still needs to spread more
        {
            int direction = Random.Range(0, 3);//choose a side to check
            //if (direction == lastDir)
            //{
            //    direction = Random.Range(0, 3);
            //}
            //lastDir = direction;
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
        RaycastHit2D hit = Physics2D.Raycast(currentObj.transform.position, direction, 1f);
        
        if(hit != false)
        {
            if (hit.collider.gameObject.tag == "Block")
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
        else
        {
            Debug.Log("hit nothing");
            ClusterSpread(currentObj, spreadValue);
            return 0;
        }
        return -1;
    }
}
