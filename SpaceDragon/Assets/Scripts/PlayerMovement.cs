using UnityEngine;
using System.Collections;
using Rewired;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour {



    public int playerId = 0;
    public Transform pivot;
    public GameObject reticle;
    public GameObject gravityArrow;
    public GameObject playerCamera;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject gun;
    public GameObject muzzleFlash;
    public int health = 3;
    public float gunRecoil = 1;
    public float cameraSpeed = 2;
    public float cursorMaxDis = 4;
    public float gravity = 1;
    public float atmosphereRadius = 2;
    bool onGround = false;
    Rigidbody2D rb2D;
    Vector3 pos;
    private Player player;
    public float moveSpeed = 4;
    public float terminalVelocity = 1;
    public float atmosphereDrag = 0.9f;
    public int blockCount = 0;
    public int metalCount = 0;
    public Text scoreText;
    public Text metalText;
    public float fireTime = 0.1f;
    float fireTimer = 0;
    public GameObject PauseMenu;
    public GameObject DefeatMenu;
    public Texture2D cursorTex;


    // Use this for initialization
    void Start () {

        //Cursor.visible = false;
        Cursor.SetCursor(cursorTex,new Vector2(0.5f,0.5f), CursorMode.Auto);

        rb2D = GetComponent<Rigidbody2D>();
        pos = transform.position;
        player = ReInput.players.GetPlayer(playerId);
    }
	
	// Update is called once per frame
	void Update () {
        //Menu
        if(player.GetButton("Pause"))
        {
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
            //Cursor.visible = true;
        }


        //
        fireTimer += Time.deltaTime;
        scoreText.text = blockCount.ToString();
        metalText.text = metalCount.ToString();
        //Fire bullet
        if (player.GetButton("Fire") && fireTimer>=fireTime)
        {
            GameObject temp = (GameObject)(Instantiate(bullet, bulletSpawn.transform.position, transform.rotation));
            GameObject temp2 = (GameObject)(Instantiate(muzzleFlash, bulletSpawn.transform.position, transform.rotation));
            temp2.transform.parent = bulletSpawn.transform;
            Vector3 direction = reticle.transform.position - transform.position;
            temp.transform.up = new Vector3(direction.normalized.x, direction.normalized.y, 0);
            temp2.transform.up = temp.transform.up;
            temp.GetComponent<Rigidbody2D>().velocity = rb2D.velocity;//.magnitude * temp.transform.up;
            rb2D.AddForce(-direction * gunRecoil);
            fireTimer = 0;
        }

        Vector3 downDirection =  pivot.position - transform.position;
        
        downDirection.Normalize();
        transform.rotation = Quaternion.LookRotation(Vector3.forward, -downDirection);
        //Ground check
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, new Vector2(downDirection.x,downDirection.y),atmosphereRadius);
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
        if (groundCheck.collider != null && player.GetAxis("Move Horizontal") == 0 && player.GetAxis("Move Vertical") == 0)
        {
            Vector2 localVel = transform.InverseTransformDirection(rb2D.velocity);
            
            if (localVel.x <= 0.1)
            {
                localVel = new Vector2(0, localVel.y);
            }
            else
            {
                localVel = new Vector2(localVel.x * atmosphereDrag, localVel.y);
            }

            rb2D.velocity = transform.TransformDirection(localVel);
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

        gravityArrow.transform.up = -downDirection;

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
        if (((Vector2)(reticle.transform.localPosition)).magnitude <= cursorMaxDis)
        {
            reticle.transform.localPosition += new Vector3(player.GetAxis("Aim Horizontal"), player.GetAxis("Aim Vertical"), 0);
            if (((Vector2)(reticle.transform.localPosition)).magnitude > cursorMaxDis)
            {
                //reticle.transform.localPosition = new Vector3(pos.x, pos.y, reticle.transform.localPosition.z);
                reticle.transform.localPosition = new Vector3(reticle.transform.localPosition.normalized.x * cursorMaxDis, reticle.transform.localPosition.normalized.y * cursorMaxDis, reticle.transform.localPosition.z);
            }
        }
        else
        {
            reticle.transform.localPosition = new Vector3(reticle.transform.localPosition.normalized.x * cursorMaxDis, reticle.transform.localPosition.normalized.y * cursorMaxDis, reticle.transform.localPosition.z);
        }

        //Gun Position
        gun.transform.localPosition = new Vector3(reticle.transform.localPosition.normalized.x, reticle.transform.localPosition.normalized.y, 0) *0.5f;
        Vector3 gunDir = (reticle.transform.position - transform.position).normalized;
        gun.transform.forward = new Vector3(gunDir.x, gunDir.y, 0);


        //Camera Movement
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

        //Change pivot
        //asteroids need to have player as child

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Time.timeScale = 0.0f;
            DefeatMenu.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Asteroid")
        {
            pivot = other.transform;
            transform.parent = other.transform;
        }
        if(other.tag == "Planet")
        {
            pivot = other.transform.transform;
            transform.parent = null;
        }
    }
}
