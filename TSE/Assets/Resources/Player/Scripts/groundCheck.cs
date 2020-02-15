using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered: " + other.tag);
        if(other.tag == "ground")
        {
            this.transform.parent.transform.parent.transform.parent.GetComponent<playerController>().isGrounded = true;
            Debug.Log("grounded");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.transform.parent.transform.parent.transform.parent.GetComponent<playerController>().isGrounded = false;
    }
}
