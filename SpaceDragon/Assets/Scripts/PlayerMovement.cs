using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerMovement : MonoBehaviour {



    public int playerId = 0;
    public Transform pivot;
    public GameObject reticle;
    public GameObject playerCamera;
    public GameObject bullet;
    public float cameraSpeed = 2;
    public float retMaxDis = 4;
    public float gravity = 1;
    public float atmosphereRadius = 2;
    bool onGround = false;
    Rigidbody2D rb2D;
    Vector3 pos;
    private Player player;
    public float moveSpeed = 4;
    public float terminalVelocity = 1;

    // Use this for initialization
    void Start () {

        Cursor.visible = false;

        rb2D = GetComponent<Rigidbody2D>();
        pos = transform.position;
        player = ReInput.players.GetPlayer(playerId);
    }
	
	// Update is called once per frame
	void Update () {

        //Fire bullet
        if (player.GetButtonDown("Fire"))
        {
            GameObject temp = (GameObject)(Instantiate(bullet, transform.position, transform.rotation));
            Vector3 direction = reticle.transform.position - transform.position;
            temp.transform.up = new Vector3(direction.normalized.x, direction.normalized.y, 0);
        }

        Vector3 downDirection = pivot.position - transform.position;
        downDirection.Normalize();
        transform.up = -downDirection;
        //Ground check
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position + downDirection, new Vector2(downDirection.x,downDirection.y),atmosphereRadius);
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

        //Atmosphere
        if(groundCheck.collider != null && player.GetAxis("Move Horizontal")== 0 && player.GetAxis("Move Vertical") == 0)
        {
            if(rb2D.velocity.magnitude <= 0.1)
            {
                rb2D.velocity.Set(0,0);
            }
            else
            {
                rb2D.AddForce(-rb2D.velocity.normalized * 5f);
                //rb2D.velocity *= 0.2f;
                //rb2D.velocity = new Vector2(rb2D.velocity.x *0.2f, rb2D.velocity.y);
            }            
        }

        //Gravity
        //if (!onGround)
        //{
        //float distance = Mathf.Abs(groundCheck.point.y - transform.position.y);
        //float heightError = floatHeight - distance;
        //float force = liftForce * heightError - rb2D.velocity.y * damping;
        //}

        if (player.GetAxis("Move Horizontal") == 0 && player.GetAxis("Move Vertical") == 0)
        {
            rb2D.AddForce(downDirection * gravity);
        }

        //Movement with Terminal Velocity
        if (rb2D.velocity.magnitude <= terminalVelocity)
        {
            rb2D.AddForce(transform.right * player.GetAxis("Move Horizontal") * moveSpeed);
            rb2D.AddForce(transform.up * player.GetAxis("Move Vertical") * moveSpeed);
        }
        else
        {
            rb2D.velocity = rb2D.velocity.normalized * terminalVelocity;
        }

        //Aiming
        if (reticle.transform.localPosition.magnitude <= retMaxDis)
        {
            reticle.transform.localPosition = new Vector3(reticle.transform.localPosition.x + player.GetAxis("Aim Horizontal"), reticle.transform.localPosition.y + player.GetAxis("Aim Vertical"), reticle.transform.localPosition.z);
            if (reticle.transform.localPosition.magnitude > retMaxDis)
            {
                reticle.transform.localPosition = reticle.transform.localPosition.normalized * retMaxDis;
            }
        }
        else
        {
            reticle.transform.localPosition = reticle.transform.localPosition.normalized * retMaxDis;
        }

        Vector3 midPoint = reticle.transform.localPosition.normalized * reticle.transform.localPosition.magnitude / 2;
        midPoint = new Vector3(midPoint.x, midPoint.y, playerCamera.transform.localPosition.z);
        if ((midPoint - playerCamera.transform.localPosition).magnitude > 0)
        {
            playerCamera.transform.localPosition += (midPoint - playerCamera.transform.localPosition) * cameraSpeed;
        }
        else
        {
            playerCamera.transform.localPosition = midPoint;
        }

    }
}
