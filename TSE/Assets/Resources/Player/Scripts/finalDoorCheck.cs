﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDoorCheck : MonoBehaviour
{
    public GameObject levelController;
    levelController LC;
    public GameObject tutorial;
    tutorialController TC;

    // Start is called before the first frame update
    void Start()
    {
        LC = levelController.GetComponent<levelController>();
        TC = tutorial.GetComponent<tutorialController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        //Show final door tutorial help if the player does not have the key yet
        if (LC.curKeys != 1)
        {
            TC.ShowFinalDoorHelp();
        }
    }
}
