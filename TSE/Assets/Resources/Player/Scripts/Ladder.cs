using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    playerController PC;
    public float climbSpeed;
    bool climbing;

    // Start is called before the first frame update
    void Start()
    {
        PC = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void FixedUpdate()
    {
        if (climbing)
        {
            player.GetComponent<Rigidbody>().useGravity = false;
            player.transform.Translate(player.transform.up * Time.deltaTime * climbSpeed);
        }
        else
        {
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    void OnTriggerStay(Collider Other)
    {
        print("Ladder: " + Other.transform.tag);
        if (Other.tag == "Player" || Other.tag == "bodypart")
        {
            if (PC.hasLArm == true && PC.hasRArm == true && Input.GetKey(KeyCode.W))
            {
                climbing = true;

            }
            else
            {
                climbing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        print("Ladder: " + Other.transform.tag);
        if (Other.tag == "Player" || Other.tag == "bodypart")
        {
            if (PC.hasLArm == true && PC.hasRArm == true && Input.GetKey(KeyCode.W))
            {
                climbing = true;
                
            }
            else
            {
                climbing = false;
            }
        }
    }
    private void OnTriggerExit(Collider Other)
    {
        climbing = false;
    }
}

