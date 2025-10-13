using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCurve : MonoBehaviour
{
    private HingeJoint2D[] joints;
    // Start is called before the first frame update
    void Start()
    {
        
    }
      
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        GameObject connectedBody = col.gameObject;

        //Update Joints        
        joints = gameObject.GetComponents<HingeJoint2D>();

        // Test if there is already a joint between these cells
        HingeJoint2D joint = null;
        foreach (HingeJoint2D joint_ in joints)
        {
            if (col.gameObject.GetInstanceID() == joint_.connectedBody.gameObject.GetInstanceID())
            {
                joint = joint_;
                break;
            }
        }


        if (!joint)
        {
            joint = connectedBody.AddComponent<HingeJoint2D>();
            // Connect Joint to colliding Object 
            joint.connectedAnchor = col.GetContact(0).point;
            joint.enableCollision = true;
            joint.breakForce = 10f ;
            
            joint.autoConfigureConnectedAnchor = false;
            
            //joint.dampingRatio =0.7f;
            //joint.frequency = 1;
            // joint.linearOffset = new Vector2(0,0);  // for relative Joint
            // joint.correctionScale = 0f; // for relative Joint
        }

    }
}
