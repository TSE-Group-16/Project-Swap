using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HideInInspector]
//generic leg controller
public class legController : MonoBehaviour, IBodypart, ILegpart
{

    float moveSpeed;
    public bool canJumpBool = false;

    public string GetBodyType()
    {
        return "leg";
    }

    public bool canJump()
    {
        return canJumpBool;
    }
}
