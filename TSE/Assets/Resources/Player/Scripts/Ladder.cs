using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    GameObject player;
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
        Debug.Log("climbing");
        if (Other.tag == "Player")
        {
            Debug.Log("playerDet");
            if (PC.hasLArm == true && PC.hasRArm == true)
            {
                Debug.Log("armsDet");
                player.GetComponent<Rigidbody>().transform.Translate(new Vector3(0, climbSpeed, 0));
            }
        }
    }
}
