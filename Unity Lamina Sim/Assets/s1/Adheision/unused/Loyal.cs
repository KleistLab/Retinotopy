using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loyal : MonoBehaviour
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
        strength = GameObject.FindGameObjectWithTag("spawner").GetComponent<Parameters>().strength_loyal;
        //add force
        force2d = gameObject.AddComponent<ConstantForce2D>() as ConstantForce2D;
        //body_this = gameObject.GetComponent<Rigidbody2D>();

        //attractor is the R8
        attractor = GameObject.Find(this.name[0] + "R8" + this.name.Substring(3, this.name.Length - 3));
        //body_att = attractor.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //set scales
        att_scale = attractor.transform.localScale;
        this_scale = this.transform.localScale;

        //update force
        force2d.force = (strength*0.005f * new Vector2((this.transform.GetChild(28).transform.position.x + this_scale.x) - (attractor.transform.GetChild(28).transform.position.x - att_scale.x),
                        (this.transform.GetChild(28).transform.position.y + this_scale.y) - (attractor.transform.GetChild(28).transform.position.y - att_scale.y)).normalized);
       
    }
}
