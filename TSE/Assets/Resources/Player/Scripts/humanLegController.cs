using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanLegController : MonoBehaviour, IBodypart, ILegpart
{
    float moveSpeed;
    public bool canJumpBool = true;
    public float timer;
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
        Physics.Raycast(boxCollider.bounds.center, )
        return true;
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
