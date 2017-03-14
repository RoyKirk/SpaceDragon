using UnityEngine;
using System.Collections;

public class BulletBehavoiur : MonoBehaviour
{

    public float bulletSpeed = 1;
    public float lifetime = 10.0f;
    public float HP = 4;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2((transform.up * bulletSpeed).x, (transform.up * bulletSpeed).y);
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        //transform.position += transform.up * bulletSpeed;
        RaycastBlock();
    }

    void RaycastBlock()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.2f);
        if (hit != false)
        {
            if (hit.collider.tag == "Block")
            {
                //trigger shot condition to fragment
                hit.collider.gameObject.GetComponent<fragmentCube>().shot = true;
            }
            else if (hit.collider.tag == "Fragment")
            {
                //dmg block and take dmg
                hit.collider.gameObject.GetComponent<BlockScript>().takeDMG(1);
                TakeDMG(1);
            }
        }
    }

    void TakeDMG(float dmg)
    {
        //reduce bullets HP
        HP -= dmg;
    }
}
