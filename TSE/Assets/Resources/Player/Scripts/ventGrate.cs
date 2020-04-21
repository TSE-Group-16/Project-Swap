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
        if (Input.GetKeyDown(KeyCode.F) && inRange == true)
        {
            Debug.Log("Grate removed");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Screwdriver")
        {
            inRange = true;
        }
        else
        {
            TC.ShowVentGrateHelp();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Screwdriver")
        {
            inRange = false;
        }
    }
}
