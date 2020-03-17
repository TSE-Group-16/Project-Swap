using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanLegController : MonoBehaviour, IBodypart, ILegpart
{
    float moveSpeed;
    public bool canJumpBool = true;
    public float timer;
    playerController PC;
    groundCheck GC;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PC = player.GetComponent<playerController>();
        GC = this.GetComponent<groundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        PC.isGrounded = GC.checkForGround();
        timer -= Time.deltaTime;
        Debug.Log("leg controller bool " + PC.isGrounded);
        if (timer <= 0)
        {

        }
    }

    public string GetBodyType()
    {
        return "leg";
    }

    public bool canJump()
    {
        return canJumpBool;
    }

    private bool Isground()
    {
        return true;
    }

    

}
