using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour
{
    Rigidbody player;

    public float speed;
    public float speedLimit;

    bool hasLeg;
    bool hasLArm;
    bool hasRArm;
    bool hasHead;


    List<GameObject> nearItems = new List<GameObject>();
    List<GameObject> attachments = new List<GameObject>();

    GameObject legSocket;
    GameObject headSocket;
    GameObject larmSocket;
    GameObject rarmSocket;
    GameObject curHead;
    GameObject curLeg;
    GameObject curLArm;
    GameObject curRAarm;

    SphereCollider itemChecker;

    

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody>();
        itemChecker = player.GetComponent<SphereCollider>();
        legSocket = player.transform.Find("LegSnapPoint").gameObject;
        headSocket = player.transform.Find("HeadSnapPoint").gameObject;
        larmSocket = player.transform.Find("LeftArmSnapPoint").gameObject;
        rarmSocket = player.transform.Find("RightArmSnapPoint").gameObject;
        Object[] prefabs = Resources.LoadAll("Player/Robot/Parts", typeof(GameObject));
        foreach (Object o in prefabs)
        {
            attachments.Add((GameObject)o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject c in nearItems)
        //{
        //    Debug.Log(c.name);
        //}

        if (Input.GetKey(KeyCode.W) && player.velocity.magnitude <= speedLimit)
        {
            player.AddForce(player.transform.forward * speed * Time.deltaTime);
            //Debug.Log(player.velocity);
        }
        if (Input.GetKey(KeyCode.A) && player.velocity.magnitude <= 5)
        {
            player.AddForce(-player.transform.right * speed*Time.deltaTime);
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

        if(Input.GetKeyDown(KeyCode.E) && nearItems.Count != 0)
        {
            Debug.Log("Equiped: " + nearItems[0].name);
            equip(nearItems[0]);
            
        }

        if(Input.GetKeyDown(KeyCode.Q)&&hasHead == true)
        {
            Debug.Log(curHead.name);
            GameObject tmp = Instantiate(attachments.Find(x => x.name == curHead.name), curHead.transform.position, curHead.transform.rotation);
            tmp.name = curHead.name;
            Destroy(curHead);
            hasHead = false;
            curHead = null;
        }

    }

    void equip(GameObject item)
    {
        string itemType = item.GetComponent<IBodypart>().GetBodyType();
        if(itemType == "head")
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
        if (itemType == "leg")
        {
            GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), legSocket.transform.position, legSocket.transform.rotation);
            tmp.name = item.name;
            Destroy(tmp.GetComponent<Rigidbody>());
            tmp.transform.parent = legSocket.transform;
            nearItems.Remove(item);
            Destroy(item);
            hasLeg = true;
            curLeg = tmp;
        }
        if (itemType == "larm")
        {
            GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), larmSocket.transform.position, larmSocket.transform.rotation);
            tmp.name = item.name;
            Destroy(tmp.GetComponent<Rigidbody>());
            tmp.transform.parent = larmSocket.transform;
            nearItems.Remove(item);
            Destroy(item);
            hasLArm = true;
            curLArm = tmp;
        }
        if (itemType == "rarm")
        {
            GameObject tmp = Instantiate(attachments.Find(x => x.name == item.name), rarmSocket.transform.position, rarmSocket.transform.rotation);
            tmp.name = item.name;
            Destroy(tmp.GetComponent<Rigidbody>());
            tmp.transform.parent = rarmSocket.transform;
            nearItems.Remove(item);
            Destroy(item);
            hasRArm = true;
            curRAarm = tmp;
        }
    }


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
}
