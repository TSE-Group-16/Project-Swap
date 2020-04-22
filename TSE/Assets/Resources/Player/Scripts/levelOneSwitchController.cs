using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOneSwitchController : MonoBehaviour
{
    IEnumerator doorOpener;

    //state bools
    bool activated = false;
    bool finishedOpeningVents = false;
    bool startedOpeningVents = false;


    float doorHeightMoved = 0.0f;
    float doorSpeed = 0.25f;


    // Update is called once per frame
    void Update()
    {
        //check if switch should activate
        if (activated && startedOpeningVents == false)
        {
            startedOpeningVents = true;
            doorOpener = openDoor(GameObject.FindGameObjectsWithTag("ventDoor"), finishedOpeningVents);
            StartCoroutine(doorOpener);
        }
    }

    //check if player has touched switch
    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.tag == "Player" || other.transform.tag == "bodypart") && activated == false)
            activated = true;
    }

    //door opener
    IEnumerator openDoor(GameObject[] doors, bool finishBool)
    {
        while (!finishBool)
        {
            foreach (GameObject door in doors)
            {
                door.transform.Translate(0, -(doorSpeed * Time.deltaTime), 0);
            }
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
