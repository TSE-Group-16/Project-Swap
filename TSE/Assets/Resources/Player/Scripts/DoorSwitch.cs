using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSwitch : MonoBehaviour
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
            door.GetComponent<slidingDoor>().Toggle();
            Debug.Log("Switch Activated");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "bodypart")
            inRange = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "bodypart")
            inRange = false;
    }
}
