using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code is frankenstein of old and new code
public class FlamingoR2R5 : MonoBehaviour
{   //all joints
    private SpringJoint2D[] joints;
    //private Rigidbody2D body;
    //max joints allowed
    public int maxjoint=1;
    //spawner object
    private GameObject spawner;//r1, r3,
    //if making new connecs for cases is allowed
    private bool new_connec1, new_connec2, new_connec3, new_connec4;
    //string where decay time comb is stored
    private string wave; //0-3
    //current status of the waves
    private bool[] waves_status = {false,false,false,false};
    //store the string char as number for each case
    private int c1, c2, c3, c4;
    //joint values
    private float strength,dm,fr;
    // Start is called before the first frame update
    void Start()
    {
        //+3 because there are 3 existing joints holding the bones together
        maxjoint += 3;
        //get spawner and attached parameters 
        spawner = GameObject.FindGameObjectWithTag("spawner");

        wave = spawner.GetComponent<Parameters>().decay_time;
        strength = spawner.GetComponent<Parameters>().joint_param[0];
        dm = spawner.GetComponent<Parameters>().joint_param[1];
        fr = spawner.GetComponent<Parameters>().joint_param[2];

        waves_status[3] = false; //no decay

        //new connections are possible
        new_connec1=true;
        new_connec2=true;
        new_connec3=true;
        new_connec4=true;

        //conversion to numbers
        c1 = Convert.ToInt32(Char.GetNumericValue(wave[0])); 
        c2 = Convert.ToInt32(Char.GetNumericValue(wave[1]));
        c3 = Convert.ToInt32(Char.GetNumericValue(wave[2]));
        c4 = Convert.ToInt32(Char.GetNumericValue(wave[3]));
    }

    // Update is called once per frame
    void Update()
    {
        //update all joints
        joints = gameObject.GetComponents<SpringJoint2D>();

        //update wave status
        waves_status[0] = (GameObject.Find(this.name[0] + "R30") != null);   // 34 spawn
        waves_status[1] = (GameObject.Find(this.name[0] + "R10") != null); // 16 spawn
        if (GameObject.Find(this.name[0] + "R10") != null) { waves_status[2] = IsGrown(GameObject.Find(this.name[0] + "R10")); }//waves_status[2]= 16 grown
        
        //Draw joints
        for (int i = 3; i < joints.Length; i++)
        {
            Vector3 other_pos = joints[i].connectedBody.position;
            if (joints[i].connectedBody is null)
                other_pos = joints[i].connectedBody.position;
            Debug.DrawLine(joints[i].attachedRigidbody.position, other_pos, Color.cyan);
        }

        //Go through joints and decide if they should be decayed
        for (int j = GetComponents<SpringJoint2D>().Length; j > 3; j--)
        {
            //if any of my connections is .fmi





            if (waves_status[c1] && this.tag == joints[j - 1].connectedBody.tag)
            {
                new_connec1 = false;
                Destroy(joints[j - 1]);

            }
            else if (waves_status[c2] && (this.name[0] == joints[j - 1].connectedBody.name[0] && ((this.name[2] == '5' && (joints[j - 1].connectedBody.name[2] == '2')) || (this.name[2] == '2' && (joints[j - 1].connectedBody.name[2] == '5')))))
            {
                new_connec2 = false;
                Destroy(joints[j - 1]);
                //new_connec = false;
            }
            else if (waves_status[c3] && joints[j - 1].connectedBody.tag == "R8b")
            {
                new_connec3 = false;
                Destroy(joints[j - 1]);
                //new_connec = false;
            }
            else if (waves_status[c4] && (Char.GetNumericValue(this.name[0]) + 1 == Char.GetNumericValue(joints[j - 1].connectedBody.name[0])) && (joints[j - 1].connectedBody.name[2] == '5') && (this.name[2] == '2'))
            {
                new_connec4 = false;
                Destroy(joints[j - 1]);
                //new_connec = false;
            }
            else if (waves_status[c4] && (Char.GetNumericValue(this.name[0]) == Char.GetNumericValue(joints[j - 1].connectedBody.name[0]) + 1) && (joints[j - 1].connectedBody.name[2] == '2') && (this.name[2] == '5'))
            {
                new_connec4 = false;
                Destroy(joints[j - 1]);
                //new_connec = false;

            }
            // if reached last wave no new "normal" flamingo sould be possible --> sonst umsonst decayed
            if (waves_status[2]) { this.GetComponent<FlamingoR2R5>().enabled = false;  }
        }
      

    }

    //old code from Sina + some tweaks regarding what to connect the joints to (the if constrictions) and joint configuration 
    // if two bones collide --> adhere
    void OnCollisionEnter2D(Collision2D col)
    {

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


        //if not bone of the same object and still joints left
        if (!name.Equals(col.gameObject.name) && GetComponents<SpringJoint2D>().Length < maxjoint)
        {

            //rework with new connec
            if (this.tag == col.gameObject.tag && new_connec1) // r2-r2 r5-r5
            {
                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 0.001f* strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio +=dm ;
                    joint.frequency +=fr ;
                    // joint.linearOffset = new Vector2(0,0);  // for relative Joint
                    // joint.correctionScale = 0f; // for relative Joint
                }
                else
                {
                    joint.enabled = true;
                }
            }
            else if ((this.name[0] == col.gameObject.name[0] && ((this.name[2] == '5' && (col.gameObject.name[2] == '2')) || (this.name[2] == '2' && (col.gameObject.name[2] == '5')))) && new_connec2) //r2-r5 r5-r2 same row
            {

                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 0.001f* strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio += dm;
                    joint.frequency += fr;
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
            else if (col.gameObject.tag == "R8b" && new_connec3) //r8
            {
                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 10 * strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio += dm;
                    joint.frequency += fr;
                    //

                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 10 * strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio += dm;
                    joint.frequency += fr;
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
            else if ((Char.GetNumericValue(this.name[0]) + 1 == Char.GetNumericValue(col.gameObject.name[0]) && new_connec4 && (col.gameObject.name[2] == '5') && this.name[2] == '2'))//r2-r5 dif row
            {


                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 0.001f * strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio += dm;
                    joint.frequency += fr;
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


            else if ((Char.GetNumericValue(this.name[0]) == Char.GetNumericValue(col.gameObject.name[0]) + 1 && new_connec4 && (col.gameObject.name[2] == '2') && this.name[2] == '5'))//r5-r2 dif row
            {


                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint2D>();
                    // Connect Joint to colliding Object 
                    joint.connectedBody = connectedBody;
                    joint.enableCollision = true;
                    joint.breakForce = 0.001f * strength;
                    joint.autoConfigureDistance = false;
                    joint.autoConfigureConnectedAnchor = false;
                    joint.dampingRatio += dm;
                    joint.frequency += fr;
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

    //check if object has grown
    //<1 is a bit hardcoded, if not there --> bugs 
    public bool IsGrown(GameObject o)
    {
        
        if (o == null) { return false; }
        if (o.transform.localScale.x < 1) { return false; }


        return true;
    }

}




