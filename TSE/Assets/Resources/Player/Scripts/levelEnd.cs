using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "bodypart")
        {
            //Load level 1 when the player reaches this trigger
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
