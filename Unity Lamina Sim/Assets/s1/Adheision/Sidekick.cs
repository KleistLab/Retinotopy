using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidekick : MonoBehaviour
{
    ////comment start

    //all joints
    private SpringJoint2D[] joints;
    //private Rigidbody2D body;
    //max joints allowed
    public int maxjoint = 2;

    // Start is called before the first frame update
    void Start()
    {
        //+3 because there are 3 existing joints holding the bones together
        maxjoint += 3;


    }

    // Update is called once per frame
    void Update()
    {   //update joints
        joints = this.GetComponents<SpringJoint2D>();

        //draw joints
        //for (int i = 3; i < joints.Length; i++)
        //{
        //    Vector3 other_pos = joints[i].connectedBody.position;
        //    if (joints[i].connectedBody is null)
        //        other_pos = joints[i].connectedBody.position;
        //    Debug.DrawLine(joints[i].attachedRigidbody.position, other_pos, Color.cyan);
        //}
    }

    //old code from Sina + some tweaks regarding what to connect the joints to (the if constrictions) and joint configuration 
    // if two bones collide --> adhere
    void OnCollisionEnter2D(Collision2D col)
    {

        //if (col.gameObject.tag == "R8")
        // {
        //     //Set only the Y axis of the velocity to a custom value, while leaving the existing x/z velocities intact by using them as the input value
        //     body.velocity = col.transform.position;
        // }


        //// Debugging
        //// Debug.Log("Names:"+col.collider.name + " "+ gameObject.name);
        //// Debug.Log("Tags:"+col.collider.tag + " "+ gameObject.tag);

        Rigidbody2D connectedBody = col.gameObject.GetComponent<Rigidbody2D>();

        //Update Joints        
        joints = gameObject.GetComponents<SpringJoint2D>();

        // Test if there is already a joint between these cells
        SpringJoint2D joint = null;
        foreach (SpringJoint2D joint_ in joints)
        {
            if (col.gameObject.GetInstanceID() == joint_.connectedBody.gameObject.GetInstanceID())
            {
                joint = joint_;
                break;
            }
        }

        // Create Joint if its not the same parent obj, and joints capacity isnt achieved

        if (!name.Equals(col.gameObject.name))
        {
            // Debug.Log(Char.GetNumericValue(col.gameObject.name[2]) == (Char.GetNumericValue(this.name[2]) + 1));

            //if Rx collided to  Rx+1 --> adhere
            if (Char.GetNumericValue(col.gameObject.name[2]) == (Char.GetNumericValue(this.name[2]) + 1) && (this.name.Substring(3) == col.gameObject.name.Substring(3))) //+same index
            {


                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint2D>();
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = float.PositiveInfinity;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    //joint.dampingRatio =0.7f;
                    //joint.frequency = 1;
                    // joint.linearOffset = new Vector2(0,0);  // for relative Joint
                    // joint.correctionScale = 0f; // for relative Joint
                }
                else
                {
                    joint.enabled = true;
                }
            }
        }
    }

    //comment end
}


