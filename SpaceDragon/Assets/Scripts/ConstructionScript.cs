using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;

public class ConstructionScript : MonoBehaviour
{

    PlayerMovement PlayerM;
    private Player player;
    int playerId = 0;


    int dirtCount;
    int metalCount;
    int ammoCount;


    public GameObject turret;
    public int turretCost = 10;

    public Text ErrorMessage;
    bool setMessage = false;
    float messageDuration = 2;
    float messageTimer;
    

    // Use this for initialization
    void Start ()
    {
        PlayerM = GetComponent<PlayerMovement>();
        playerId = PlayerM.playerId;
        player = ReInput.players.GetPlayer(playerId);
    }
	
	// Update is called once per frame
	void Update ()
    {
        dirtCount = PlayerM.blockCount;
        metalCount = PlayerM.metalCount;

        if(setMessage)
        {
            messageTimer -= Time.deltaTime;
        }
        else
        {
            messageTimer = messageDuration;
            setMessage = false;
        }

        if (messageTimer <= 0)
        {
            SetErrorMessage("");
        }
        


        if(player.GetButtonDown("Alt Fire"))
        {
            //placing a turret
            if(metalCount >= turretCost)
            {
                Instantiate(turret, transform.position, transform.rotation);
                PlayerM.metalCount -= turretCost;
            }
            else
            {
                SetErrorMessage("Not Enough Metal");
            }
            
        }
    }

    void SetErrorMessage(string message)
    {
        ErrorMessage.text = message;
        if(message != "")
        {
            setMessage = true;
        }
    }
}
