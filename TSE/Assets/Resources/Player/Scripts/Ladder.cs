using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
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

    private void OnTriggerEnter(Collider Other)
    {
        print("Ladder: " + Other.transform.tag);
        if (Other.tag == "Player" || Other.tag == "bodypart")
        {
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
    private void OnTriggerExit(Collider Other)
    {
        PC.isClimbing = false;
    }
}

