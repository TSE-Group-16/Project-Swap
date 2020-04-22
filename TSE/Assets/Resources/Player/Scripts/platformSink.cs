using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSink : MonoBehaviour
{
    public Vector3 originPoint = new Vector3();
    public Vector3 lowestPoint = new Vector3();
    public bool sinking = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //initialise
        originPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        lowestPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-5, gameObject.transform.position.z);
        Physics.IgnoreLayerCollision(9, 9);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //check if platform should be sinking and act accordingly
        if (sinking && gameObject.transform.position != lowestPoint) 
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.01f, gameObject.transform.position.z);
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.01f, player.transform.position.z);
        }
        else if (!sinking && gameObject.transform.position != originPoint)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.01f, gameObject.transform.position.z);
        }
    }


    //check if player is on platform
    void OnCollisionEnter (Collision collision) 
    { 
        if (collision.gameObject.CompareTag("Player")) 
        {
            sinking = true;
        }
    }

    void OnCollisionExit (Collision other) 
    { 
        if (other.gameObject.CompareTag("Player")) 
        {
            sinking = false;   
        }
    }
}
