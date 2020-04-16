using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    playerController PC;

    // Start is called before the first frame update
    void Start()
    {
        PC = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    void OnTriggerStay(Collider Other)
    {
        //Check if player has both arms
        if (Other.tag == "Player" || Other.tag == "bodypart")
        {
            if (PC.hasLArm == true && PC.hasRArm == true)
            {
                player.GetComponent<Rigidbody>().useGravity = false;
                PC.climbing = true;
            }
            else
            {
                PC.climbing = false;
            }
        }
    }
    private void OnTriggerExit(Collider Other)
    {
        PC.climbing = false;
        player.GetComponent<Rigidbody>().useGravity = true;
    }
}

