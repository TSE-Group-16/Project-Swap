using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legCheck : MonoBehaviour
{
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

    }

    void OnTriggerEnter()
    {
       //Show leg tutorial when trigger is entered
       TC.ShowLegsHelp();
    }
}
