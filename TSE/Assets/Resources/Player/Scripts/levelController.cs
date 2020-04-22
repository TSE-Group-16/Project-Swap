using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    int keyTotal;
    public int curKeys;
    public bool win = false;
    IEnumerator doorOpener;
    bool activated = false;
    bool finishedOpeningVents = false;
    bool startedOpeningVents = false;
    float doorHeightMoved = 0.0f;
    float doorSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        //initialise
        keyTotal = GameObject.FindGameObjectsWithTag("key").Length;
        curKeys = 0;
        print(keyTotal);
    }

    // Update is called once per frame
    void Update()
    {
        //check if player has all keys
        if (keyTotal == curKeys)
            win = true;

        //check if player has completed level
        if (win)
        {
            print("WINNER");
            doorOpener = openDoor(GameObject.FindGameObjectWithTag("finalDoor"), finishedOpeningVents);
            StartCoroutine(doorOpener);
        }
    }

    //door opener
    IEnumerator openDoor(GameObject door, bool finishBool)
    {
        while (!finishBool)
        {
            door.transform.Translate(0, -(doorSpeed * Time.deltaTime), 0);
            doorHeightMoved += 0.1f * Time.deltaTime;
            if (doorHeightMoved >= 2.5)
            {
                print("Door Done");
                finishBool = true;
                StopCoroutine(doorOpener);
            }
            yield return null;
        }


    }
}
