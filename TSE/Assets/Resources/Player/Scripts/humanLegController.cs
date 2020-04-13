using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanLegController : MonoBehaviour, IBodypart, ILegpart, IJump
{
    float moveSpeed;
    public bool canJumpBool = true;
    public float jumpMultFloat = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetBodyType()
    {
        return "leg";
    }

    public bool canJump()
    {
        return canJumpBool;
    }

    public float jumpMult()
    {
        return jumpMultFloat;
    }



    

}
