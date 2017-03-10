using UnityEngine;
using System.Collections;

public class BulletBehavoiur : MonoBehaviour {

    public float bulletSpeed = 1;
    public float lifetime = 10.0f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
	void Update () {
        transform.position += transform.up * bulletSpeed;
	}
}
