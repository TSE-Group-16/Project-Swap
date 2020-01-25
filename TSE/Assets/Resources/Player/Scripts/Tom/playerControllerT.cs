using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerT : MonoBehaviour
{
    public float x; //Use for x-axis movement
    public float z; //use for z-axis movement (when required)
    public int armValue; //Use to store the player's arm slot attachments
    public int legValue; //Use to store the player's leg slot attachments
    public Rigidbody rb; //Easier to use than typing out getcomponent every time
    public Vector3 movement; //Use to store the player's movement
    public List<GameObject> pickups = new List<GameObject>(); //List of active pickups
    // Use this for initialization
    void Start()
    {
        armValue = 0; //armValue and legValue both start at 0, as the
        legValue = 0; //player begins with their default limbs.
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (legValue) //A different case exists for each legValue - in other words, different controls for movement
        {
            case 0:
                x = Input.GetAxis("Horizontal") / 5; //Dividing by 5 because otherwise the player moves too fast
                z = Input.GetAxis("Vertical") / 5;   //This will likely not be how the default controls work in the actual game, but they suffice for this prototype
                movement = new Vector3(x, 0, z);
                rb.MovePosition(rb.position + movement); //Moves the object in the direction the player indicates
                break;
            case 1:
                x = Input.GetAxis("Horizontal") / 4; //Dividing by 5 because otherwise the player moves too fast
                z = Input.GetAxis("Vertical") / 4;   //This will likely not be how the default controls work in the actual game, but they suffice for this prototype
                movement = new Vector3(x, 0, z);
                rb.MovePosition(rb.position + movement); //Moves the object in the direction the player indicates
                if (Input.GetButtonDown("x")) drop(); //If the player presses x, they return to normal
                break;
            default:
                Console.WriteLine("Error: No legs detected at all"); //This should never come up, but is in here anyway just in case
                break;
        }

    }

    public void legSwap(int newLeg)
    { //The function to swap parts - as it's a public function, this may be called from other objects as long as they have the player as a gameObject within their code. 
        legValue = newLeg;            //The value of newLeg - the new legValue - is also provided by the other objects, so different pickups can give you different parts.

        //This space can be used to run any animations or anything associated with swapping parts. For now, I'll settle for just changing the colour of the object.
        Console.WriteLine("Leg swap performed successfully");
    }

    public void armSwap(int newArm)
    {  //See legSwap above - this is the same, but for arms.

        armValue = newArm;
        //more room for animation commands

    }

    public void drop() 
    {   //A function allowing the player to drop all their pickups - must drop both at the same time, at least for now
        armValue = 0;
        legValue = 0; 
        for (int i = 0; i < pickups.Count; i++)
        {
            pickups[i].SetActive(true);
        }
        pickups.Clear(); 

        //more room for animation commands

    }

    public void add(GameObject pickup)
    { //A function to keep track of all the pickups the player has active, so they can be restored to their original states when they're no longer in use
        pickups.Add(pickup);
    }

}
    