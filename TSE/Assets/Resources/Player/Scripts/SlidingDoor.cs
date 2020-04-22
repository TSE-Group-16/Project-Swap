using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoor : MonoBehaviour
{
    public float openSpeed;
    public float openDistance;
    public bool isOpen;
    private float closedPos;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        closedPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        //check if door is in position and move
        if (transform.position.y < closedPos + openDistance && isOpen == true)
        {
            Vector3 pos = transform.position;
            pos.y += openSpeed;
            transform.position = pos;
        }
        if (transform.position.y > closedPos && isOpen == false)
        {
            Vector3 pos = transform.position;
            pos.y -= openSpeed;
            transform.position = pos;
        }
    }

    //toggle door open/closed
    public void Toggle()
    {
        if (isOpen == false)
        {
            isOpen = true;
            Debug.Log("Open");
        }
        else
        {
            isOpen = false;
            Debug.Log("Closed");
        }
    }
}
