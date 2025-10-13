using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    //comment start
    private SpringJoint2D[] joints;

    public int maxjoint = 1;

    //spawner object
    private GameObject spawner;
    private bool glue;

    private float strength, dm, fr;
    // Start is called before the first frame update
    void Start()
    {
        maxjoint = +10;
       

        spawner = GameObject.FindGameObjectWithTag("spawner");

        strength = spawner.GetComponent<Parameters>().joint_param[0];
        dm = spawner.GetComponent<Parameters>().joint_param[1];
        fr = spawner.GetComponent<Parameters>().joint_param[2];
        glue = spawner.GetComponent<Parameters>().GLUE;
    }

    // Update is called once per frame
    void Update()
    {
        joints = gameObject.GetComponents<SpringJoint2D>();
        
    }


    //old code from Sina + some tweaks regarding what to connect the joints to (the if constrictions)
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

        // Create Joint

        if (col.gameObject.name[1] == 'R' && glue)
        {
            if (!name.Equals(col.gameObject.name))
            {
              
                    if (!joint)
                    {
                        joint = gameObject.AddComponent<SpringJoint2D>();
                        // Connect Joint to colliding Object 
                        joint.connectedBody = connectedBody;
                        joint.enableCollision = true;
                        joint.breakForce = 777;
                    joint.autoConfigureDistance = false;
                        joint.autoConfigureConnectedAnchor = false;
                        joint.dampingRatio += dm;
                        joint.frequency += fr;

                    }
                    else
                    {
                        joint.enabled = true;
                    }
                


            }


        }
    }


}
