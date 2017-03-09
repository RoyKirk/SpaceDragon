using UnityEngine;
using System.Collections;

public class BulletBehavoiur : MonoBehaviour {

    public float bulletSpeed = 1;

	void Update () {
        transform.position += transform.up * bulletSpeed;
	}
}
