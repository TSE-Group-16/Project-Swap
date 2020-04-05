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
            player.transform.Translate(player.transform.up * Time.deltaTime * climbSpeed);
    }
    //void OnTriggerEnter(Collider Other)
    //{
    //    print("Ladder: " + Other.transform.tag);
    //    if (Other.tag == "Player" || Other.tag == "bodypart")
    //    {
    //        if (PC.hasLArm == true && PC.hasRArm == true && Input.GetKey(KeyCode.W))
    //        {
    //            player.GetComponent<Rigidbody>().transform.Translate(new Vector3(0, climbSpeed, 0));
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider Other)
    {
        print("Ladder: " + Other.transform.tag);
        if (Other.tag == "Player" || Other.tag == "bodypart")
        {
            if (PC.hasLArm == true && PC.hasRArm == true && Input.GetKey(KeyCode.W))
            {
                climbing = true;
                
            }
        }
    }
    private void OnTriggerExit(Collider Other)
    {
        climbing = false;
    }
}

