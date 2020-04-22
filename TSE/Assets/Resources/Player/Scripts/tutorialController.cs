using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialController : MonoBehaviour
{
    public GameObject moveHelp;
    public GameObject grateHelp;
    public GameObject ladderHelp;
    public GameObject ventHelp;
    public GameObject ventGrateHelp;
    public GameObject finalDoorHelp;
    public GameObject legsHelp;

    // Start is called before the first frame update
    void Start()
    {
        //Disable all tutorial UI
        grateHelp.SetActive(false);
        ladderHelp.SetActive(false);
        moveHelp.SetActive(false);
        ventHelp.SetActive(false);
        ventGrateHelp.SetActive(false);
        finalDoorHelp.SetActive(false);
        legsHelp.SetActive(false);

        //Start level with move tutorial
        ShowMoveHelp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //All functions below enable the specified tutorial and then call the hide after 5 seconds function

    public void ShowMoveHelp()
    {
        moveHelp.SetActive(true);
        print("show move help");
        StartCoroutine(Hide5Seconds());
    }

    public void ShowLadderHelp()
    {
        ladderHelp.SetActive(true);
        print("show ladder help");
        StartCoroutine(Hide5Seconds());
    }

    public void ShowGrateHelp()
    {
        grateHelp.SetActive(true);
        print("show grate help");
        StartCoroutine(Hide5Seconds());
    }

    public void ShowVentHelp()
    {
        ventHelp.SetActive(true);
        print("show vent help");
        StartCoroutine(Hide5Seconds());
    }
    public void ShowVentGrateHelp()
    {
        ventGrateHelp.SetActive(true);
        print("show vent grate help");
        StartCoroutine(Hide5Seconds());
    }
    public void ShowFinalDoorHelp()
    {
        finalDoorHelp.SetActive(true);
        print("show final door help");
        StartCoroutine(Hide5Seconds());
    }
    public void ShowLegsHelp()
    {
        legsHelp.SetActive(true);
        print("show legs help");
        StartCoroutine(Hide5Seconds());
    }


    IEnumerator Hide5Seconds()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After 5 seconds hide all tutorial UI
        grateHelp.SetActive(false);
        ladderHelp.SetActive(false);
        moveHelp.SetActive(false);
        ventHelp.SetActive(false);
        ventGrateHelp.SetActive(false);
        finalDoorHelp.SetActive(false);
        legsHelp.SetActive(false);
    }
}
