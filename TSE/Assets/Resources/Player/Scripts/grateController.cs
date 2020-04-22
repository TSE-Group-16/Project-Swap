using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grateController : MonoBehaviour
{
    [SerializeField]
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
        if (PC.getCurLeg() != null)
        {
            Debug.Log("has leg");
            //If player has tracks
            if (PC.getCurLeg().name == "Tracks")
            {
                //Enable hitbox
                this.GetComponent<BoxCollider>().enabled = true;
                Debug.Log("has right leg");
            }
            else
            {
                //Disable hitbox
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            //Disable hitbox
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter()
    {
        //If player has incorrect legs then show the grate tutorial
        if (PC.getCurLeg() == null)
        {
            TC.ShowGrateHelp();
        }
        else if(PC.getCurLeg().name != "Tracks")
        {
            TC.ShowGrateHelp();
        }
    }
}
