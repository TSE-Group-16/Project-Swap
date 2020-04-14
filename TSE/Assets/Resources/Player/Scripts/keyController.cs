using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    levelController lc;
    bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        lc = GameObject.Find("LevelController").GetComponent<levelController>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.tag);
        if ((other.transform.tag == "Player" || other.transform.tag == "bodypart") && !collected)
        {
            collected = true;
            lc.curKeys++;
            print("key: " + lc.curKeys);
            Destroy(this.gameObject);
        }
    }
}
