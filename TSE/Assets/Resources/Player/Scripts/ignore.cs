using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //prevent collisions on layer
        Physics.IgnoreLayerCollision(9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
