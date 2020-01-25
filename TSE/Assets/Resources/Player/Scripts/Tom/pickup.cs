using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int pickupValue;
    public string pickupType;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        pickupValue = 1;
        pickupType = "leg";
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupType == "leg")
        {
            if (player.GetComponent<playerControllerT>().legValue == pickupValue)
            {
                gameObject.SetActive(false);
            }
        }
        else if (pickupType == "arm")
        {
            if (player.GetComponent<playerControllerT>().armValue == pickupValue)
            {
                gameObject.SetActive(false);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<playerControllerT>().add(gameObject);
            if (pickupType == "leg")
            {
                player.GetComponent<playerControllerT>().legSwap(pickupValue);
            }
            else if (pickupType == "arm")
            {
                player.GetComponent<playerControllerT>().armSwap(pickupValue);
            }
        }
    }
}