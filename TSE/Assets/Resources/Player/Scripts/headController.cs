using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headController : MonoBehaviour, IBodypart
{

    public string GetBodyType()
    {
        return ("head");
    }
}
