using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armController : MonoBehaviour, IBodypart
{

    public string GetBodyType()
    {
        return ("arm");
    }

}
