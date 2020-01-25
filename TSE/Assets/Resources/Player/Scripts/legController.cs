using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HideInInspector]

public class legController : MonoBehaviour, IBodypart
{

    float moveSpeed;
    bool canJump;
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
}
