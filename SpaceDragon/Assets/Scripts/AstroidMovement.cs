using UnityEngine;
using System.Collections;

public class AstroidMovement : MonoBehaviour
{
    public GameObject astroidPrefab;
    GameObject astroidClone;

    public Vector3 spawnPos;

    Vector3 velocity;
    public float moveSpeed;
    public float rotateSpeed;
    public float orbitDistance;

    public float SpawnTimer;
    float spawnCooldown;
    bool isSpawned;
    bool isLeaving;

    public float astroidDuration;
    float astroidLifetime;


	// Use this for initialization
	void Start ()
    {
        spawnCooldown = SpawnTimer;
        astroidLifetime = astroidDuration;
        velocity.x = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isSpawned == false)
        {
            spawnCooldown -= Time.deltaTime;

            if(spawnCooldown <= 0)
            {
                SpawnAstroid();
            }
        }

        if(isSpawned == true)
        {
            MoveAstroid();
            astroidLifetime -= Time.deltaTime;

            if(astroidLifetime <= 0)
            {
                isLeaving = true;
            }
        }
	}

    void SpawnAstroid()
    {
        astroidClone = Instantiate(astroidPrefab, this.transform, false) as GameObject;
        astroidClone.transform.position = spawnPos;//.transform.position;
        astroidLifetime = astroidDuration;
        isSpawned = true;
        isLeaving = false;
    }

    void MoveAstroid()
    {
        if(isLeaving)
        {
            astroidClone.transform.localPosition += velocity * moveSpeed * Time.deltaTime;

            if(Vector3.Distance(transform.position, astroidClone.transform.position) > orbitDistance * 2)
            {
                DespawnAstroid();
            }
        }

        if(astroidClone != null && Vector3.Distance(transform.position, astroidClone.transform.position) > orbitDistance)
        {
            astroidClone.transform.position += velocity * moveSpeed * Time.deltaTime;
        }

        if (astroidClone != null && Vector3.Distance(transform.position, astroidClone.transform.position) <= orbitDistance)
        {
            transform.Rotate(Vector3.forward * -1 * rotateSpeed * Time.deltaTime);
        }
    }

    void DespawnAstroid()
    {
        Destroy(astroidClone.gameObject);
        spawnCooldown = SpawnTimer;
        isSpawned = false;

        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
