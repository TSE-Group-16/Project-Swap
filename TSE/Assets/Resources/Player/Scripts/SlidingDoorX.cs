using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorX : MonoBehaviour
{
    public float openSpeed;
    public float openDistance;
    public bool isOpen;
    public bool direction = true;
    public float closedPos;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        closedPos = transform.position.x;
        Physics.IgnoreLayerCollision(9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == true)
        {
            if (transform.position.x < closedPos + openDistance && isOpen == true)
            {
                Vector3 pos = transform.position;
                pos.x += openSpeed;
                transform.position = pos;
            }
            if (transform.position.x > closedPos && isOpen == false)
            {
                Vector3 pos = transform.position;
                pos.x -= openSpeed;
                transform.position = pos;
            }
        }
        else if (direction == false) 
        {
            if (transform.position.x > closedPos - openDistance && isOpen == true)
            {
                Vector3 pos = transform.position;
                pos.x -= openSpeed ;
                transform.position = pos;
            }
            if (transform.position.x < closedPos && isOpen == false)
            {
                Vector3 pos = transform.position;
                pos.x += openSpeed;
                transform.position = pos;
            }
        }
        if (Input.GetKeyDown("o")) Toggle();
    }

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

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("Collided with " + collision.collider.gameObject.name);
    }
}
