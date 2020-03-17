using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    Bounds bounds;
    playerController PC;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PC = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkForGround()
    {
        bounds = this.transform.GetComponent<BoxCollider>().bounds;
        RaycastHit rayCenter;
        RaycastHit rayLeftCenter;
        RaycastHit rayRightCenter;
        RaycastHit rayFrontLeft;
        RaycastHit rayFrontRight;
        RaycastHit rayBackLeft;
        RaycastHit rayBackRight;
        Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayCenter, 0.1f);
        Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x, this.transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z), -this.transform.up, out rayLeftCenter, 0.1f);
        Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayRightCenter, 0.1f);
        Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up, out rayBackLeft, 0.1f);
        Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up, out rayBackRight, 0.1f);
        Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up, out rayFrontLeft, 0.1f);
        Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up, out rayFrontRight, 0.1f);
        print("checking for ground");
        Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up * 0.1f, Color.blue);
        Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x, this.transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z), -this.transform.up * 0.1f, Color.red);
        Debug.Log(Vector3.Scale(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z), -this.transform.right));
        Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up * 0.1f, Color.black);
        Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up * 0.1f, Color.yellow);
        Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up * 0.1f, Color.green);
        Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up * 0.1f, Color.magenta);
        if (Physics.Raycast(new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z) ,-this.transform.up,out rayCenter, 0.1f) && rayCenter.transform.tag == "ground" || Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z- this.bounds.extents.z), -this.transform.up, out rayBackLeft, 0.1f) && rayBackLeft.transform.tag == "ground" || Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up, out rayBackRight, 0.1f) && rayBackRight.transform.tag == "ground" || Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up, out rayFrontRight, 0.1f) && rayFrontRight.transform.tag == "ground" || Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up, out rayFrontLeft, 0.1f) && rayFrontLeft.transform.tag == "ground")
        {
            print(rayFrontLeft.normal);
            print(rayLeftCenter.normal);
            print("success");
            if (rayFrontLeft.distance >= rayLeftCenter.distance)
            {
                print("moving forward");
                PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal, -PC.transform.right);
                return true;
            }
            else if (rayFrontRight.normal == rayRightCenter.normal)
            {
                PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
                return true;
            }
            else if (rayBackRight.normal == rayRightCenter.normal)
            {
                PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
                return true;
            }
            else if (rayBackLeft.normal == rayLeftCenter.normal)
            {
                PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayCenter, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayCenter.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayLeftCenter, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayRightCenter, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up, out rayBackLeft, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayBackLeft.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z - this.bounds.extents.z), -this.transform.up, out rayBackRight, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayBackRight.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up, out rayFrontLeft, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayFrontLeft.normal, -PC.transform.right);
                return true;
            }
            else if (Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x, this.transform.position.y, this.transform.position.z + this.bounds.extents.z), -this.transform.up, out rayFrontRight, 0.1f))
            {
                PC.forwardAngle = Vector3.Cross(rayFrontRight.normal, -PC.transform.right);
                return true;
            }
        }
        print("falied");
        
        return false;
    }

}
