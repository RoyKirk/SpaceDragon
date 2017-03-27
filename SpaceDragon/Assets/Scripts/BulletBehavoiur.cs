using UnityEngine;
using System.Collections;

public class BulletBehavoiur : MonoBehaviour
{

    public float bulletSpeed = 1;
    public float lifetime = 10.0f;
    public float HP = 4;

    public GameObject shootParticle;

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
        //RaycastBlock();
    }

    void RaycastBlock()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.2f);
        if (hit != false)
        {
            if (hit.collider.tag == "Block")
            {
                //trigger shot condition to fragment
                if(hit.collider.gameObject.GetComponent<fragmentCube>().typeValue <= 2)
                {
                    hit.collider.gameObject.GetComponent<fragmentCube>().TakeDamage(1);// = true;
                }
                else
                {
                    Instantiate(shootParticle, transform.position, Quaternion.identity);
                    TakeDMG(HP);
                }
            }
            else if (hit.collider.tag == "Fragment")
            {
                //dmg block and take dmg
                hit.collider.gameObject.GetComponent<BlockScript>().takeDMG(1,true);
                TakeDMG(1);
            }
        }
    }

    void TakeDMG(float dmg)
    {
        //reduce bullets HP
        HP -= dmg;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if (collision.gameObject.GetComponent<fragmentCube>().typeValue <= 2)
            {
                collision.gameObject.GetComponent<fragmentCube>().TakeDamage(1);// = true;
                //if (collision.gameObject.GetComponent<fragmentCube>() != 0)
                //{
                    TakeDMG(HP);
                //}
            }
            else
            {
                Instantiate(shootParticle, transform.position, Quaternion.identity);
                TakeDMG(HP);
            }
        }
        else if (collision.gameObject.tag == "Fragment")
        {
            //dmg block and take dmg
            collision.gameObject.GetComponent<BlockScript>().takeDMG(1,true);
            TakeDMG(1);
        }
    }
}
