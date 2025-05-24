
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateFlamingo : MonoBehaviour
{
    //comment start

    private SpringJoint2D[] joints;
    private Rigidbody2D body;
    public int maxjoint = 1;
    private bool case1, case2, case3, case4, case5, case6, case7, case8, mode, cc_mode;
    private float strength, dm, fr;
    private GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner");
        mode = spawner.GetComponent<Parameters>().mode;
        cc_mode = spawner.GetComponent<Parameters>().cc_mode;
        maxjoint += 7;
        //strength = GameObject.FindGameObjectWithTag("spawner").GetComponent<Parameters>().joint_param_late[0];
        //dm = GameObject.FindGameObjectWithTag("spawner").GetComponent<Parameters>().joint_param_late[1];
        //fr = GameObject.FindGameObjectWithTag("spawner").GetComponent<Parameters>().joint_param_late[2];

        strength = 1.0f;
        dm = 0.0f;
        fr = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        joints = this.GetComponents<SpringJoint2D>();
        //for (int i = 3; i < joints.Length; i++)
        //{
        //    Vector3 other_pos = joints[i].connectedBody.position;
        //    if (joints[i].connectedBody is null)
        //        other_pos = joints[i].connectedBody.position;
        //    Debug.DrawLine(joints[i].attachedRigidbody.position, other_pos, Color.cyan);
        //}
        //for (int i = 3; i < joints.Length; i++)
        //{
        //    Vector3 other_pos = joints[i].connectedBody.position;
        //    if (joints[i].connectedBody is null)
        //        other_pos = joints[i].connectedBody.position;
        //    Debug.DrawLine(joints[i].attachedRigidbody.position, other_pos, Color.cyan);
        //}

    }


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
        ///
        if (!mode)
        {
            case1 = ((Char.GetNumericValue(this.name[0]) == Char.GetNumericValue(col.gameObject.name[0]) + 1) && (this.name[2] == '5') && (col.gameObject.name[2] == '1'));
            case2 = ((Char.GetNumericValue(this.name[0]) + 1 == Char.GetNumericValue(col.gameObject.name[0])) && (this.name[2] == '2') && (col.gameObject.name[2] == '6'));
            case3 = ((Char.GetNumericValue(this.name[0]) + 1 == Char.GetNumericValue(col.gameObject.name[0])) && (this.name[2] == '1') && (col.gameObject.name[2] == '5'));
            case4 = ((Char.GetNumericValue(this.name[0]) == Char.GetNumericValue(col.gameObject.name[0]) + 1) && (this.name[2] == '6') && (col.gameObject.name[2] == '2'));
        }
        else if (mode || cc_mode)
        {
            //  any 2-5, 2-2, 5-5, 1-5, 6-2 connection

            case1 = ((this.name[2] == '5') && (col.gameObject.name[2] == '1'));
            case2 = ((this.name[2] == '2') && (col.gameObject.name[2] == '6'));
            case3 = ((this.name[2] == '1') && (col.gameObject.name[2] == '5'));
            case4 = ((this.name[2] == '6') && (col.gameObject.name[2] == '2'));
            case5 = ((this.name[2] == '5') && (col.gameObject.name[2] == '2'));
            case6 = ((this.name[2] == '2') && (col.gameObject.name[2] == '5'));
            case7 = ((this.name[2] == '2') && (col.gameObject.name[2] == '2'));
            case8 = ((this.name[2] == '5') && (col.gameObject.name[2] == '5'));
        }


        //Debug.Log((Char.GetNumericValue(this.name[0]) + 1 == Char.GetNumericValue(col.gameObject.name[0])) && (this.name[2] == '5') && (col.gameObject.name[2] == '1'));
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

        // Create  Joint

        if (!name.Equals(col.gameObject.name) && GetComponents<SpringJoint2D>().Length < maxjoint)//
        {
            if (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8) //
            {

                if (!joint)
                {

                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 10000 * strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio += dm;
                    joint.frequency += fr;
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

