using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Transform pivot;
    public float gravity = 1;
    bool onGround = false;
    Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 downDirection = pivot.position - transform.position;
        downDirection.Normalize();
        transform.up = -downDirection;
        //Ground check
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position + downDirection, new Vector2(downDirection.x,downDirection.y));
        Debug.DrawRay(transform.position, 100*downDirection);
        if (groundCheck.collider != null)
        {
            if (groundCheck.distance <= 1.0f)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
        else
        {
            onGround = false;
        }

        //Gravity
        if (!onGround)
        {
            //float distance = Mathf.Abs(groundCheck.point.y - transform.position.y);
            //float heightError = floatHeight - distance;
            //float force = liftForce * heightError - rb2D.velocity.y * damping;
            rb2D.AddForce(downDirection * gravity);
        }

        rb2D.AddForce(transform.right * 0.1f);

    }
}
