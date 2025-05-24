using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyFlamingo : MonoBehaviour
{
    //comment start
    private SpringJoint2D[] joints;
    private Rigidbody2D body;
    public int maxjoint = 1;
    private bool new_connec, new_connec8;
    //spawner object
    private GameObject spawner;
    //string where decay time comb is stored
    private string wave; //0-3
    //current status of the waves
    private bool[] waves_status = { false, false, false, false };
    //store the string char as number for each case
    private int c1, c2, c3, c4;

    private float strength, dm, fr;
    // Start is called before the first frame update
    void Start()
    {
        maxjoint = +3;
        new_connec = true;


        spawner = GameObject.FindGameObjectWithTag("spawner");

        strength = spawner.GetComponent<Parameters>().joint_param[0];
        dm = spawner.GetComponent<Parameters>().joint_param[1];
        fr = spawner.GetComponent<Parameters>().joint_param[2];
    }

    // Update is called once per frame
    void Update()
    {
        joints = gameObject.GetComponents<SpringJoint2D>();
        //update wave status


        for (int j = GetComponents<SpringJoint2D>().Length; j > 3; j--)
        {    //if me or any of my connections is .fmi =false
            // if partner 
            //{ decay }
            if ((joints[j - 1].connectedBody.transform.parent.gameObject.GetComponent<State>()?.fmi) == false && joints[j - 1].breakForce == 0.001f)
            {
                //Debug.Log(this.name+ "  "+joints[j - 1].connectedBody.transform.parent.gameObject.name);
                Destroy(joints[j - 1]);
                //new_connec = false;
                continue;

            }
         
            // if me 
            //{ decay + no new connec}
            if (this.transform.parent.gameObject.GetComponent<State>().fmi == false && joints[j - 1].breakForce == 0.001f)
            {

                Destroy(joints[j - 1]);
                new_connec = false;

            }
           



            if (waves_status[2]) { this.GetComponent<EarlyFlamingo>().enabled = false; }
        }
        //for (int i = 3; i < joints.Length; i++)
        //{
        //    Vector3 other_pos = joints[i].connectedBody.position;
        //    if (joints[i].connectedBody is null)
        //        other_pos = joints[i].connectedBody.position;
        //    Debug.DrawLine(joints[i].attachedRigidbody.position, other_pos, Color.cyan);
        //}

    }


    //old code from Sina + some tweaks regarding what to connect the joints to (the if constrictions)
    void OnCollisionEnter2D(Collision2D col)
    {
        /* if (col.gameObject.tag == "R8")
         {
             //Set only the Y axis of the velocity to a custom value, while leaving the existing x/z velocities intact by using them as the input value
             body.velocity = col.transform.position;
         }

         */
        // Debugging
        // Debug.Log("Names:"+col.collider.name + " "+ gameObject.name);
        // Debug.Log("Tags:"+col.collider.tag + " "+ gameObject.tag);

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

        // Create Joint

        if (GetComponents<SpringJoint2D>().Length <= maxjoint)
        {
            if (!name.Equals(col.gameObject.name))
            {
                if (((col.gameObject.name[2] == '2') || (col.gameObject.name[2] == '5')) || (col.gameObject.name[2] == '8') && new_connec && (col.gameObject.transform.parent.gameObject.GetComponent<State>().fmi))// + collision patner fmi true
                {
                    if (!joint)
                    {
                        joint = gameObject.AddComponent<SpringJoint2D>();
                        // Connect Joint to colliding Object 
                        joint.connectedBody = connectedBody;
                        joint.enableCollision = true;
                        joint.breakForce = 0.001f;
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
    }

    //growth check (UNUSED?)
    public bool IsGrown(GameObject o)
    {

        if (o == null) { return false; }
        if (o.transform.localScale.x < 1) { return false; }


        return true;
    }



    //comment end
}



