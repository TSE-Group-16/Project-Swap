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
    float checkDist = 0.25f;
    LayerMask mask;



    // Start is called before the first frame update
    void Start()
    {
        //initialise
        GameObject player = GameObject.Find("Player");
        PC = player.GetComponent<playerController>();
        mask = LayerMask.GetMask("Player");
        mask = ~mask;
    }


    //check if the player is grounded through raycasts
    public bool checkForGround()
    {
        //declare taycasts
        RaycastHit rayCenter;
        RaycastHit rayLeftCenter;
        RaycastHit rayRightCenter;
        RaycastHit rayFrontLeft;
        RaycastHit rayFrontRight;
        RaycastHit rayBackLeft;
        RaycastHit rayBackRight;

        //fire raycasts from body or leg
        if (PC.hasLeg)
        {
            bounds = PC.getCurLeg().GetComponentInChildren<MeshFilter>().mesh.bounds;
            centerHit = Physics.Raycast(new Vector3(this.transform.position.x, PC.getCurLeg().transform.position.y, this.transform.position.z), -this.transform.up, out rayCenter, checkDist, mask);
            leftCenterHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up, out rayLeftCenter, checkDist, mask);
            rightCenterHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up, out rayRightCenter, checkDist, mask);
            frontLeftHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up, out rayFrontLeft, checkDist, mask);
            frontRightHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up, out rayFrontRight, checkDist, mask);
            backLeftHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up, out rayBackLeft, checkDist, mask);
            backRightHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (-this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up, out rayBackRight, checkDist, mask);
            //draw rays for debugging in editor
            Debug.DrawRay(new Vector3(this.transform.position.x, PC.getCurLeg().transform.position.y, this.transform.position.z), -this.transform.up * rayCenter.distance, Color.blue);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up * rayLeftCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up * rayRightCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up * rayBackRight.distance, Color.black);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up * rayFrontRight.distance, Color.yellow);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up * rayFrontLeft.distance, Color.green);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, PC.getCurLeg().transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up * rayBackLeft.distance, Color.magenta);
        }
        else
        {
            bounds = this.transform.Find("Robot Body").GetComponentInChildren<MeshFilter>().mesh.bounds;
            centerHit = Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up, out rayCenter, checkDist, mask);
            leftCenterHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.6f, this.transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up, out rayLeftCenter, checkDist, mask);
            rightCenterHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.6f, this.transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up, out rayRightCenter, checkDist, mask);
            frontLeftHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up, out rayFrontLeft, checkDist, mask);
            frontRightHit = Physics.Raycast(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up, out rayFrontRight, checkDist, mask);
            backLeftHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up, out rayBackLeft, checkDist, mask);
            backRightHit = Physics.Raycast(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (-this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up, out rayBackRight, checkDist, mask);
            //draw rays for debugging in editor
            Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), -this.transform.up * rayCenter.distance, Color.blue);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * this.transform.right.x * 0.6f, this.transform.position.y, this.transform.position.z - bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up * rayLeftCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * this.transform.right.x * 0.6f, this.transform.position.y, this.transform.position.z + bounds.extents.z * this.transform.right.z * 0.6f), -this.transform.up * rayRightCenter.distance, Color.red);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up * rayBackRight.distance, Color.black);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z + this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up * rayFrontRight.distance, Color.yellow);
            Debug.DrawRay(new Vector3(this.transform.position.x + bounds.extents.x * (-this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + -this.transform.forward.z) * 0.6f), -this.transform.up * rayFrontLeft.distance, Color.green);
            Debug.DrawRay(new Vector3(this.transform.position.x - bounds.extents.x * (this.transform.right.x + this.transform.forward.x) * 0.6f, this.transform.position.y, this.transform.position.z - this.bounds.extents.z * (this.transform.right.z + this.transform.forward.z) * 0.6f), -this.transform.up * rayBackLeft.distance, Color.magenta);
        }

        //calculate angle of movement based on where the ground is and angle of ground
        if (frontLeftHit && leftCenterHit && (rayFrontLeft.transform.tag == "ground" || rayFrontLeft.transform.tag == "bodypart") && rayFrontLeft.normal.y <= rayLeftCenter.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayFrontLeft.normal, -PC.transform.right);
            return true;
        }
        else if (leftCenterHit && backLeftHit && (rayCenter.transform.tag == "ground" || rayCenter.transform.tag == "bodypart") && rayLeftCenter.normal.y <= rayBackLeft.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal.normalized, -PC.transform.right.normalized);
            return true;
        }
        else if (frontRightHit && rightCenterHit && (rayFrontRight.transform.tag == "ground" || rayFrontRight.transform.tag == "bodypart") && rayFrontRight.normal.y <= rayRightCenter.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayFrontRight.normal, -PC.transform.right);
            return true;
        }
        else if (rightCenterHit && backRightHit && (rayRightCenter.transform.tag == "ground" || rayRightCenter.transform.tag == "bodypart") && rayRightCenter.normal.y <= rayBackRight.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
            return true;
        }
        else if (leftCenterHit && backLeftHit && (rayLeftCenter.transform.tag == "ground" || rayLeftCenter.transform.tag == "bodypart") && rayLeftCenter.normal.y >= rayBackLeft.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayBackLeft.normal, -PC.transform.right);
            return true;
        }
        else if (frontLeftHit && leftCenterHit && (rayFrontLeft.transform.tag == "ground" || rayFrontLeft.transform.tag == "bodypart") && rayFrontLeft.normal.y >= rayLeftCenter.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayLeftCenter.normal, -PC.transform.right);
            return true;
        }
        else if (rightCenterHit && backRightHit && (rayRightCenter.transform.tag == "ground" || rayRightCenter.transform.tag == "bodypart") && rayRightCenter.normal.y >= rayBackRight.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayBackRight.normal, -PC.transform.right);
            return true;
        }
        else if (frontRightHit && rightCenterHit && (rayFrontRight.transform.tag == "ground" || rayFrontRight.transform.tag == "bodypart") && rayFrontRight.normal.y >= rayRightCenter.normal.y)
        {
            PC.forwardAngle = Vector3.Cross(rayRightCenter.normal, -PC.transform.right);
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
        return false;
    }

}
