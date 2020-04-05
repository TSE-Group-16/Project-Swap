using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOneSwitchController : MonoBehaviour
{
    IEnumerator doorOpener;
    bool activated = false;
    bool finishedOpeningVents = false;
    float doorHeightMoved = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            doorOpener = openDoor(GameObject.FindGameObjectsWithTag("ventDoor"), finishedOpeningVents);
            StartCoroutine(doorOpener);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" || other.tag == "bodypart")
            activated = true;
    }

    IEnumerator openDoor(GameObject[] doors, bool finishBool)
    {
        if (!finishBool)
        {
            foreach (GameObject door in doors)
            {
                door.transform.Translate(door.transform.position.x, door.transform.position.y - (0.1f * Time.deltaTime), door.transform.position.z);
                doorHeightMoved += 0.1f * Time.deltaTime;
            }
            if (doorHeightMoved >= 0.7)
                finishBool = true;
        }

        yield return null;
    }
}
