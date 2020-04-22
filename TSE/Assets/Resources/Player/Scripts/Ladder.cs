﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    public GameObject player;
    playerController PC;
    public GameObject tutorial;
    tutorialController TC;

    // Start is called before the first frame update
    void Start()
    {
        PC = player.GetComponent<playerController>();
        TC = tutorial.GetComponent<tutorialController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider Other)
    {
        print("Ladder: " + Other.transform.tag);
        if (Other.tag == "Player" || Other.tag == "bodypart")
        {
            //The player is told it is climbing if they have both arms and pressing W when touching the ladder
            if (PC.hasLArm == true && PC.hasRArm == true && Input.GetKey(KeyCode.W))
            {
                PC.isClimbing = true;
            }
            else
            {
                PC.isClimbing = false;
            }
        }
    }

    void OnTriggerEnter()
    {
        //Show ladder tutorial when player doesn't have both arms
        if (PC.hasLArm == false || PC.hasRArm == false)
        {
            TC.ShowLadderHelp();
        }
    }

    void OnTriggerExit(Collider Other)
    {
        PC.isClimbing = false;
    }
}

