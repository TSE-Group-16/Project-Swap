﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour
{
    Rigidbody player;

    public float speed;
    public float speedLimit;
    public float jumpForce;

    bool hasLeg;
    public bool hasLArm;
    public bool hasRArm;
    bool hasHead;
    bool isFrozen;
    bool isJumping = false;
    public bool isGrounded = false;


    List<GameObject> nearItems = new List<GameObject>();
    List<GameObject> attachments = new List<GameObject>();

    GameObject legSocket;
    GameObject headSocket;
    GameObject lArmSocket;
    GameObject rArmSocket;
    GameObject curHead = null;
    GameObject curLeg = null;
    GameObject curLArm = null;
    GameObject curRAarm = null;
    [SerializeField]
    GameObject radialMenu;
    [SerializeField]
    GameObject cameraObj;
    cameraController camCont;

    SphereCollider itemChecker;

    

    // Start is called before the first frame update
    void Start()
    {
        //initialise variables
        player = this.GetComponent<Rigidbody>();
        camCont = cameraObj.GetComponent<cameraController>();
        itemChecker = player.GetComponent<SphereCollider>();
        legSocket = player.transform.Find("LegSnapPoint").gameObject;
        headSocket = player.transform.Find("HeadSnapPoint").gameObject;
        lArmSocket = player.transform.Find("LeftArmSnapPoint").gameObject;
        rArmSocket = player.transform.Find("RightArmSnapPoint").gameObject;
        radialMenu.SetActive(false);
        //load all body parts into an array to instantiate them when needed
        Object[] prefabs = Resources.LoadAll("Player/Robot/Parts", typeof(GameObject));
        foreach (Object o in prefabs)
        {
            attachments.Add((GameObject)o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is frozen e.g. when menu is open
        if (!isFrozen)
        {
            if (Input.GetKey(KeyCode.W) && player.velocity.magnitude <= speedLimit)
            {
                player.AddForce(player.transform.forward * speed * Time.deltaTime);
                //Debug.Log(player.velocity);
            }
            if (Input.GetKey(KeyCode.A) && player.velocity.magnitude <= 5)
            {
                player.AddForce(-player.transform.right * speed * Time.deltaTime);
                //Debug.Log(player.velocity);
            }
            if (Input.GetKey(KeyCode.S) && player.velocity.magnitude <= 5)
            {
                player.AddForce(-player.transform.forward * speed * Time.deltaTime);
                //Debug.Log(player.velocity);
            }
            if (Input.GetKey(KeyCode.D) && player.velocity.magnitude <= 5)
            {
                player.AddForce(player.transform.right * speed * Time.deltaTime);
                //Debug.Log(player.velocity);
            }
            if (Input.GetKeyDown(KeyCode.Space) && hasLeg && curLeg.GetComponent<ILegpart>().canJump() && !isJumping)
            {
                player.AddForce(player.transform.up * jumpForce);
                isJumping = true;
            }


            //!!!!!grounded not working yet!!!!!
            if (isJumping && isGrounded)
            {
                isJumping = false;
            }

            //pick up nearest item
            if (Input.GetKeyDown(KeyCode.E) && nearItems.Count != 0)
            {
                Debug.Log("Equiped: " + nearItems[0].name);
                equip(nearItems[0]);

            }

            Debug.Log(isGrounded + "," + isJumping);
        }
        //open and close drop menu
        if(Input.GetKeyDown(KeyCode.Q))
        {
            radialMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            camCont.isFrozen = true;
            isFrozen = true;
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            radialMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            camCont.isFrozen = false;
            isFrozen = false;
        }

        //reset player's x and z rotation
        player.transform.eulerAngles = new Vector3(0, player.transform.rotation.eulerAngles.y, 0);
    }

    //drop functions
    public void dropHead()
    {
        Debug.Log(curHead.name);
        Vector3 tmpPos = curHead.transform.position;
        Quaternion tmpRot = curHead.transform.rotation;
        GameObject tmpObj = attachments.Find(x => x.name == curHead.name);
        string tmpName = curHead.name;
        Destroy(curHead);
        GameObject tmp = Instantiate(tmpObj, tmpPos + new Vector3(0.0f, 0.1f, 0.0f), tmpRot);
        tmp.name = tmpName;
        tmp.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(Random.Range(-100f, 100f), 100f, Random.Range(-100f, 100f)), new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)));
        hasHead = false;
        curHead = null;
    }

    public void dropLegs()
    {
        Debug.Log(curLeg.name);
        Vector3 tmpPos = curLeg.transform.position;
        Quaternion tmpRot = curLeg.transform.rotation;
        GameObject tmpObj = attachments.Find(x => x.name == curLeg.name);
        string tmpName = curLeg.name;
        Destroy(curLeg);
        GameObject tmp = Instantiate(tmpObj, tmpPos + new Vector3(0.0f, 0.1f, 0.0f), tmpRot);
        tmp.name = tmpName;
        tmp.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(100f, Random.Range(-100f, 100f), Random.Range(-100f, 100f)), new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)));
        hasLeg = false;
        curLeg = null;
    }

    public void dropLArm()
    {
        Debug.Log(curLArm.name);
        Vector3 tmpPos = curLArm.transform.position;
        Quaternion tmpRot = curLArm.transform.rotation;
        GameObject tmpObj = attachments.Find(x => x.name == curLArm.name);
        string tmpName = curLArm.name;
        Destroy(curLArm);
        GameObject tmp = Instantiate(tmpObj, tmpPos + new Vector3(0.0f, 0.1f, 0.0f), tmpRot);
        tmp.name = tmpName;
        tmp.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(100f, Random.Range(-100f, 100f), Random.Range(-100f, 100f)), new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)));
        hasLArm = false;
        curLArm = null;
    }

    public void dropRArm()
    {
        Debug.Log(curRAarm.name);
        Vector3 tmpPos = curRAarm.transform.position;
        Quaternion tmpRot = curRAarm.transform.rotation;
        GameObject tmpObj = attachments.Find(x => x.name == curRAarm.name);
        string tmpName = curRAarm.name;
        Destroy(curRAarm);
        GameObject tmp = Instantiate(tmpObj, tmpPos + new Vector3(0.0f, 0.1f, 0.0f), tmpRot);
        tmp.name = tmpName;
        tmp.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(100f, Random.Range(-100f, 100f), Random.Range(-100f, 100f)), new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)));
        hasRArm = false;
        curRAarm = null;
    }


    //equip item
    void equip(GameObject item)
    {
        string itemType = item.GetComponent<IBodypart>().GetBodyType();
        if(itemType == "head" && hasHead == false)
        {
            GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), headSocket.transform.position, headSocket.transform.rotation);
            tmp.name = item.name;
            Destroy(tmp.GetComponent<Rigidbody>());
            tmp.transform.parent = headSocket.transform;
            nearItems.Remove(item);
            Destroy(item);
            hasHead = true;
            curHead = tmp;
            
        }
        if (itemType == "leg" && hasLeg == false)
        {
            
            GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), legSocket.transform.position, legSocket.transform.rotation);
            tmp.name = item.name;
            Destroy(tmp.GetComponent<Rigidbody>());
            tmp.transform.parent = legSocket.transform;
            nearItems.Remove(item);
            Destroy(item);
            hasLeg = true;
            curLeg = tmp;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);

            if(curLeg.GetComponent<ILegpart>().canJump())
            {
                curLeg.GetComponentInChildren<BoxCollider>().enabled = true;
            }
        }
        if (itemType == "arm")
        {
            if (hasLArm == false)
            {
                GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), lArmSocket.transform.position, lArmSocket.transform.rotation);
                tmp.name = item.name;
                Destroy(tmp.GetComponent<Rigidbody>());
                tmp.transform.parent = lArmSocket.transform;
                nearItems.Remove(item);
                Destroy(item);
                hasLArm = true;
                curLArm = tmp;
            }
            else if(hasRArm == false)
            {
                GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), rArmSocket.transform.position, rArmSocket.transform.rotation);
                tmp.name = item.name;
                Destroy(tmp.GetComponent<Rigidbody>());
                tmp.transform.parent = rArmSocket.transform;
                nearItems.Remove(item);
                Destroy(item);
                hasRArm = true;
                curRAarm = tmp;
            }

        }

    }

    //check for nearby body parts
    private void OnTriggerEnter(Collider other)
    {
        if (!nearItems.Contains(other.gameObject) && other.tag == "bodypart")
        {
            nearItems.Add(other.gameObject);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if(nearItems.Contains(other.gameObject))
        {
            nearItems.Remove(other.gameObject);
        }
    }

    //getter functions
    public GameObject getCurHead()
    {
        return curHead;
    }

    public GameObject getCurLeg()
    {
        return curLeg;
    }

    public GameObject getCurLArm()
    {
        return curLArm;
    }

    public GameObject getCurRArm()
    {
        return curRAarm;
    }
}
