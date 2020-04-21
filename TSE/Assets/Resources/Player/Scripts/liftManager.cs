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
    bool entered = true;
    bool inside = false;

    // Update is called once per frame
    void Lift()
    {
        otherLift.GetComponent<liftManager>().entered = false;
        otherLift.GetComponent<liftManager>().inside = true;
        Debug.Log("Lift test");
        toggleAllDoors();
        StartCoroutine("Timer");
        
    }


        void toggleAllDoors() 
    {
        door1.GetComponent<SlidingDoorX>().Toggle();
        door2.GetComponent<SlidingDoorX>().Toggle();
        door3.GetComponent<SlidingDoorX>().Toggle();
        door4.GetComponent<SlidingDoorX>().Toggle();
    }

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

    void OnTriggerEnter(Collider other)
    {
        if (entered && !inside)
            Lift();
    }

    void OnTriggerExit(Collider other) 
    {
        entered = true;
        inside = false;
        otherLift.GetComponent<liftManager>().inside = false;
    }
}

