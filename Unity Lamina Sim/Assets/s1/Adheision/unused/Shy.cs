using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy : MonoBehaviour
{
    //body which the force is correlated to
    private GameObject attractor;
    //sterngth of the force
    private float strength;

    //locations if bodies
    private Vector3 att_scale, this_scale;
    //private Rigidbody2D body_this, body_att;
    //2d force applied
    private ConstantForce2D force2d;

    // Start is called before the first frame update
    void Start()
    {
        //set to global params given by spawner
        strength = GameObject.FindGameObjectWithTag("spawner").GetComponent<Parameters>().strength_shy;

        //add force
        force2d = gameObject.AddComponent<ConstantForce2D>() as ConstantForce2D;
        //body_this = gameObject.GetComponent<Rigidbody2D>();//child transform?rigidbody

        //set attractor (in this case repellent)
        Debug.Log(this.tag);
        if (this.tag == "R1")
        {
            attractor = GameObject.Find(this.name[0] + "R6" + this.name.Substring(3, this.name.Length - 3)); //child transform?rigidbody
        }
        else if (this.tag == "R6") { 
            attractor = GameObject.Find(this.name[0] + "R1" + this.name.Substring(3, this.name.Length - 3));
            
        }
        
       // body_att = attractor.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //set scales
        att_scale = attractor.transform.localScale;
        this_scale = this.transform.localScale;

        //update force
        force2d.force = (strength * (-0.01f) * new Vector2((this.transform.position.x + this_scale.x) - (attractor.transform.position.x - att_scale.x),
                        (this.transform.position.y + this_scale.y) - (attractor.transform.position.y - att_scale.y)).normalized); 
        //same as loyal but oppositer direktion, 
    }
}
