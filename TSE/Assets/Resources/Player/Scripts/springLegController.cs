using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springLegController : MonoBehaviour, IBodypart, ILegpart, IJump
{
    float moveSpeed;
    public bool canJumpBool = true;
    public float jumpMultFloat = 2.0f;


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
