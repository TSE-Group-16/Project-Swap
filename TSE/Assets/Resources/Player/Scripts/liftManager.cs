using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftManager : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject player;
    public GameObject otherLift;

    //state bools
    bool entered = true;
    bool inside = false;
    bool teleporting = false;
    bool teleported = false;

    //Activate lift func
    void Lift()
    {
        teleporting = true;
        otherLift.GetComponent<liftManager>().entered = false;
        otherLift.GetComponent<liftManager>().inside = true;
        Debug.Log("Lift test");
        toggleAllDoors();
        StartCoroutine("Timer");

    }

    //close all doors
    void toggleAllDoors()
    {
        door1.GetComponent<SlidingDoorX>().Toggle();
        door2.GetComponent<SlidingDoorX>().Toggle();
        door3.GetComponent<SlidingDoorX>().Toggle();
        door4.GetComponent<SlidingDoorX>().Toggle();
    }

    //timer func until player should teleport and the teleport
    IEnumerator Timer()
    {
        Debug.Log("Timer begun");
        yield return new WaitForSeconds(3);
        Debug.Log("Timer ended");
        if (player.GetComponent<Transform>().position.y > 10)
            player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y - 11.736236f, player.GetComponent<Transform>().position.z);
        else if (player.GetComponent<Transform>().position.y < 10)
            player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y + 11.736236f, player.GetComponent<Transform>().position.z);
        toggleAllDoors();
    }

    //check when player enters lift
    void OnTriggerEnter(Collider other)
    {
        if (entered && !inside && !teleported)
            Lift();
        if (teleporting && !teleported)
        {
            teleported = true;
            teleporting = false;
        }
    }

    //check when player exists lift
    void OnTriggerExit(Collider other)
    {
        entered = true;
        inside = false;
        otherLift.GetComponent<liftManager>().inside = false;
        if (teleported)
        {
            teleported = false;
            teleporting = false;
        }
    }
}

