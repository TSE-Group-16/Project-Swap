using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanLegController : MonoBehaviour, IBodypart, ILegpart
{
    float moveSpeed;
    public bool canJumpBool = true;

    public static playerController PC;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PC = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("leg controller bool " + PC.isGrounded);
    }

    public string GetBodyType()
    {
        return "leg";
    }

    public bool canJump()
    {
        return canJumpBool;
    }

    public void OnTriggerEnter(Collider legsTagger)
    {
        Debug.Log("inside on trigger stay");
        if (legsTagger.gameObject.CompareTag("ground"))
        {
            Debug.Log("ground touched");
            PC.isGrounded = true;
            Debug.Log(PC.isGrounded);
        }
    }

}
