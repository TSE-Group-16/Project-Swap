using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HideInInspector]
//generic leg controller
public class legController : MonoBehaviour, IBodypart, ILegpart
{

    float moveSpeed;
    public bool canJumpBool = false;
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
}
