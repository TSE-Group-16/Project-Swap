using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    int keyTotal;
    public int curKeys;
    bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        keyTotal = GameObject.FindGameObjectsWithTag("key").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyTotal == curKeys)
            win = true;
    }
}
