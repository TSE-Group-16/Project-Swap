using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    playerController PC;
    public float climbSpeed;

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
        if (Other.tag == "Player")
        {
            if (PC.hasLArm == true && PC.hasRArm == true)
            {
                player.GetComponent<Rigidbody>().transform.Translate(new Vector3(0, climbSpeed, 0));
            }
        }
    }
}
