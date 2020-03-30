using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    Bounds bounds;
    playerController PC;
    bool centerHit = false;
    bool leftCenterHit = false;
    bool rightCenterHit = false;
    bool frontLeftHit = false;
    bool frontRightHit = false;
    bool backLeftHit = false;
    bool backRightHit = false;
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
        RaycastHit rayCenter;
        RaycastHit rayLeftCenter;
        RaycastHit rayRightCenter;
        RaycastHit rayFrontLeft;
        RaycastHit rayFrontRight;
        RaycastHit rayBackLeft;
        RaycastHit rayBackRight;
        if (PC.hasLeg)
        {
            bounds = PC.getCurLeg().GetComponentInChildren<MeshFilter>().mesh.bounds;
            centerHit = Physics.Raycast(new Vector3(this.transform.position.x, PC.getCurLeg().transform.position.y, this.transform.position.z), -this.transform.up, out rayCenter, 0.15f);
            leftCenterHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up, out rayLeftCenter, 0.15f);
            rightCenterHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up, out rayRightCenter, 0.15f);
            frontLeftHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up, out rayBackRight, 0.15f);
            frontRightHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up, out rayFrontRight, 0.15f);
            backLeftHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up, out rayFrontLeft, 0.15f);
            backRightHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up, out rayBackLeft, 0.15f);
            Debug.DrawRay(new Vector3(this.transform.position.x, PC.getCurLeg().transform.position.y, this.transform.position.z), -this.transform.up * rayCenter.distance, Color.blue);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up * rayLeftCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up * rayRightCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up * rayBackRight.distance, Color.black);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up * rayFrontRight.distance, Color.yellow);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up * rayFrontLeft.distance, Color.green);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up * rayBackLeft.distance, Color.magenta);
        }
        else
        {
            bounds = this.transform.Find("Robot Body").GetComponentInChildren<MeshFilter>().mesh.bounds;
            centerHit = Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayCenter, 0.1f);
            leftCenterHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.4f, this.transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up, out rayLeftCenter, 0.1f);
            rightCenterHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.4f, this.transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up, out rayRightCenter, 0.1f);
            frontLeftHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up, out rayBackRight, 0.1f);
            frontRightHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up, out rayFrontRight, 0.1f);
            backLeftHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up, out rayFrontLeft, 0.1f);
            backRightHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up, out rayBackLeft, 0.1f);
            Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up * rayCenter.distance, Color.blue);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.4f, this.transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up * rayLeftCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.4f, this.transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.4f), -this.transform.up * rayRightCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up * rayBackRight.distance, Color.black);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up * rayFrontRight.distance, Color.yellow);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.4f), -this.transform.up * rayFrontLeft.distance, Color.green);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.4f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.4f), -this.transform.up * rayBackLeft.distance, Color.magenta);
        }
        
        if (centerHit && rayCenter.transform.tag == "ground" || backLeftHit && rayBackLeft.transform.tag == "ground" || backRightHit && rayBackRight.transform.tag == "ground" || frontRightHit && rayFrontRight.transform.tag == "ground" || frontLeftHit && rayFrontLeft.transform.tag == "ground")
        {
            print(rayFrontLeft.normal.x + "," + rayFrontLeft.normal.y + "," + rayFrontLeft.normal.z);
            print(rayLeftCenter.normal);
            print(-PC.transform.right.x + "," + -PC.transform.right.y + "," + -PC.transform.right.z);
            print(rayFrontLeft.transform.tag);
            if (rayFrontLeft.normal.y <= rayLeftCenter.normal.y)
            {
                print("FL <= LC");
                PC.forwardAngle = Vector3.Cross(rayFrontLeft.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (rayLeftCenter.normal.y <= rayBackLeft.normal.y)
            {
                print("LC <= BL");
                PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal.normalized, -PC.transform.right.normalized);
                print("fw" + PC.forwardAngle);
                return true;
            }

            else if (rayFrontRight.normal.y <= rayRightCenter.normal.y)
            {
                print("FR <= RC");
                PC.forwardAngle = Vector3.Cross(rayFrontRight.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (rayRightCenter.normal.y <= rayBackRight.normal.y)
            {
                print("RC <= BR");
                PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (rayLeftCenter.normal.y >= rayBackLeft.normal.y)
            {
                print("LC >= BL");
                PC.forwardAngle = Vector3.Cross(rayBackLeft.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (rayFrontLeft.normal.y >= rayLeftCenter.normal.y)
            {
                print("FL >= LC");
                PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (rayRightCenter.normal.y >= rayBackRight.normal.y)
            {
                print("RC >= BR");
                PC.forwardAngle = Vector3.Cross(rayBackRight.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (rayFrontRight.normal.y >= rayRightCenter.normal.y)
            {
                print("FR >= RC");
                PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
                print("fw" + PC.forwardAngle);
                return true;
            }
            else if (frontLeftHit)
            {
                PC.forwardAngle = Vector3.Cross(rayFrontLeft.normal, -PC.transform.right);
                return true;
            }
            else if (frontRightHit)
            {
                PC.forwardAngle = Vector3.Cross(rayFrontRight.normal, -PC.transform.right);
                return true;
            }
            else if (leftCenterHit)
            {
                PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal, -PC.transform.right);
                return true;
            }
            else if (rightCenterHit)
            {
                PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
                return true;
            }
            else if (centerHit)
            {
                PC.forwardAngle = Vector3.Cross(rayCenter.normal, -PC.transform.right);
                return true;
            }
            else if (backLeftHit)
            {
                PC.forwardAngle = Vector3.Cross(rayBackLeft.normal, -PC.transform.right);
                return true;
            }
            else if (backRightHit)
            {
                PC.forwardAngle = Vector3.Cross(rayBackRight.normal, -PC.transform.right);
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
