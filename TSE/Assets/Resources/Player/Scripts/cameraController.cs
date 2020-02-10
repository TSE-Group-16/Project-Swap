using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class cameraController : MonoBehaviour
{
    public Rigidbody player;
    public BoxCollider playerBounds;


    public float turnSpeed;
    public bool isFrozen = false;

    float cameraMagnitude;
    Vector3 cameraPosLocal;
    
    [Range(0.0f, 5.0f)]
    public float camDistY;
    [Range(0.0f, 5.0f)]
    public float camDistZ;
    IEnumerator rotator;

    Camera cam;
    GameObject cameraOrigin;




    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = this.transform.Find("CameraOrigin").Find("Main Camera").GetComponent<Camera>();
        cameraOrigin = this.transform.Find("CameraOrigin").gameObject;
        cameraOrigin.transform.position = new Vector3(player.transform.position.x, playerBounds.bounds.center.y, player.transform.position.z);
        cam.transform.localPosition = new Vector3(0, camDistY, -camDistZ);
        cameraPosLocal = cam.transform.position;
        cameraMagnitude = Vector3.Magnitude(cam.transform.position - cameraOrigin.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        cameraOrigin.transform.position = new Vector3(player.transform.position.x, playerBounds.bounds.center.y, player.transform.position.z);
        if (!isFrozen)
        {

            cameraOrigin.transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0), Space.World);
            cameraOrigin.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0.0f, 0));



            if (cameraOrigin.transform.eulerAngles.x < 300.0f && cameraOrigin.transform.eulerAngles.x > 180.0f)
            {

                cameraOrigin.transform.eulerAngles = new Vector3(300.0f, cameraOrigin.transform.eulerAngles.y, cameraOrigin.transform.eulerAngles.z);
            }
            else if (cameraOrigin.transform.eulerAngles.x > 35.0f && cameraOrigin.transform.eulerAngles.x <= 180.0f)
            {

                cameraOrigin.transform.eulerAngles = new Vector3(35.0f, cameraOrigin.transform.eulerAngles.y, cameraOrigin.transform.eulerAngles.z);
            }




            float difference = Vector3.Angle(new Vector3(player.transform.forward.x, 0, player.transform.forward.z), new Vector3(cameraOrigin.transform.forward.x, 0, cameraOrigin.transform.forward.z));

            Vector3 perp = Vector3.Cross(player.transform.forward, cameraOrigin.transform.forward);
            float dir = Vector3.Dot(perp, player.transform.up);


            if (dir > 0f)
            {
                if (difference > 2.0f && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
                {
                    rotator = playerRotateRight(difference);
                    StartCoroutine(rotator);
                }
            }
            else if (dir < 0f && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                if (difference > 2.0f)
                {
                    rotator = playerRotateLeft(difference);
                    StartCoroutine(rotator);
                }
            }


            cameraOrigin.transform.eulerAngles = new Vector3(cameraOrigin.transform.eulerAngles.x, cameraOrigin.transform.eulerAngles.y, 0.0f);
            RaycastHit ray;
            int playerMask = 1 << 8;
            playerMask = ~playerMask;
            if (Physics.Raycast(cameraOrigin.transform.position, Vector3.Normalize(cam.transform.position - cameraOrigin.transform.position), out ray, cameraMagnitude))
            {
                cam.transform.position = ray.point;
            }
            else
            {
                cam.transform.localPosition = new Vector3(0, camDistY, -camDistZ);
            }
        }

    }

    IEnumerator playerRotateLeft(float angle)
    {
        for (float i = angle; i > 0; i -= angle / 5)
        {
            player.transform.Rotate(0.0f, ((-i)) * Time.deltaTime * turnSpeed, 0.0f, Space.Self);
            yield return null;
        }
    }

    IEnumerator playerRotateRight(float angle)
    {
        for (float i = angle; i > 0; i -= angle / 5)
        {
            player.transform.Rotate(0.0f, (i) * Time.deltaTime * turnSpeed, 0.0f);
            yield return null;
        }
    }
}