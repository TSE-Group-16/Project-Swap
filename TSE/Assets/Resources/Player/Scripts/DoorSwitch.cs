using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject door;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            door.GetComponent<SlidingDoor>().Toggle();
            Debug.Log("Switch Activated");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "bodypart")
            inRange = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "bodypart")
            inRange = false;
    }
}
