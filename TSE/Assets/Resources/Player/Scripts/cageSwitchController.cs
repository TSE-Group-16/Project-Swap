using System.Collections;
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


    // Update is called once per frame
    void Update()
    {
        //check if the door has been activated
        if (activated && startedOpeningVents == false)
        {
            startedOpeningVents = true;
            doorOpener = openDoor(GameObject.FindGameObjectWithTag("cageDoor"), finishedOpeningVents);
            StartCoroutine(doorOpener);
        }
    }

    //check if player touches switch
    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "Player" || other.transform.tag == "bodypart") && activated == false)
            activated = true;
    }

    //door opener
    IEnumerator openDoor(GameObject door, bool finishBool)
    {
        while (!finishBool)
        {
            door.transform.Translate(0, -(doorSpeed * Time.deltaTime), 0);
            doorHeightMoved += 0.1f * Time.deltaTime;
            if (doorHeightMoved >= 0.7)
            {
                finishBool = true;
                StopCoroutine(doorOpener);
            }
            yield return null;
        }


    }
}
