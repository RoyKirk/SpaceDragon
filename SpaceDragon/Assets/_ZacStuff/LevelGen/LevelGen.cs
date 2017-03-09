using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour
{

    public GameObject baseBlock;
    public int width;
    public int height;
	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                Instantiate(baseBlock, new Vector3((float)i*2 , (float)x*2, 0), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
