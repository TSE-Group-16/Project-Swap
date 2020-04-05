using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearBodypartCheckSCript : MonoBehaviour
{
    playerController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check for nearby body parts
    private void OnTriggerEnter(Collider other)
    {
        if (!PC.nearItems.Contains(other.gameObject) && other.tag == "bodypart")
        {
            PC.nearItems.Add(other.gameObject);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (PC.nearItems.Contains(other.gameObject))
        {
           PC.nearItems.Remove(other.gameObject);
        }
    }
}
