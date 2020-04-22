using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventCheck : MonoBehaviour
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

    void OnTriggerEnter()
    {
        //Show vent tutorial when player enters trigger with legs
        if (PC.getCurLeg() != null)
        {
            TC.ShowVentHelp();
        }
    }
}
