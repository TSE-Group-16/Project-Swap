using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventGrate : MonoBehaviour
{
    private bool inRange;
    public GameObject tutorial;
    tutorialController TC;

    // Start is called before the first frame update
    void Start()
    {
        TC = tutorial.GetComponent<tutorialController>();
    }

    // Update is called once per frame
    void Update()
    {
        //When player presses F the vent will be removed if screwdriver is in range
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            Debug.Log("Grate removed");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If screwdriver in hitbox then inRange is true
        if (other.name == "Screwdriver")
        {
            inRange = true;
        }
        else
        {
            //Show vent grate tutorial
            TC.ShowVentGrateHelp();
        }
    }
    void OnTriggerExit(Collider other)
    {
        //inRange is false if screwdriver leaves hitbox
        if (other.name == "Screwdriver")
        {
            inRange = false;
        }
    }
}
