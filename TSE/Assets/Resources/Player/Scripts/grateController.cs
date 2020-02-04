using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grateController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    playerController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PC.getCurLeg() != null)
        {
            Debug.Log("has leg");
            if (PC.getCurLeg().name == "Tracks")
            {
                this.GetComponent<BoxCollider>().enabled = false;
                Debug.Log("has right leg");
            }
            else
            {
                this.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
