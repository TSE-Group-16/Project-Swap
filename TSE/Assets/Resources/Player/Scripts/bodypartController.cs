using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interfaces for bodyparts

public interface IBodypart
{
    string GetBodyType();
}


public interface ILegpart
{
    bool canJump();
}