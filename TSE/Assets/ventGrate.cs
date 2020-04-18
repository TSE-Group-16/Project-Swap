using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventGrate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            Debug.Log("Grate removed");
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
