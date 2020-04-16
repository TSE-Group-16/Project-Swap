﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cageSwitchController : MonoBehaviour
{
    IEnumerator doorOpener;
    public bool activated = false;
    bool finishedOpeningVents = false;
    bool startedOpeningVents = false;
    float doorHeightMoved = 0.0f;
    float doorSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activated && startedOpeningVents == false)
        {
            //print("Activated");
            startedOpeningVents = true;
            doorOpener = openDoor(GameObject.FindGameObjectWithTag("cageDoor"), finishedOpeningVents);
            StartCoroutine(doorOpener);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other);
        if ((other.transform.tag == "Player" || other.transform.tag == "bodypart") && activated == false)
            activated = true;
    }

    IEnumerator openDoor(GameObject door, bool finishBool)
    {
        while (!finishBool)
        {
            //print("Moving Door" + door);
            door.transform.Translate(0, -(doorSpeed * Time.deltaTime), 0);

            //print(doorSpeed * Time.deltaTime);
            //print(doorHeightMoved);
            doorHeightMoved += 0.1f * Time.deltaTime;
            if (doorHeightMoved >= 0.7)
            {
                //print("Door Done");
                finishBool = true;
                StopCoroutine(doorOpener);
            }
            yield return null;
        }


    }
}
