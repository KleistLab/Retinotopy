using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descent : MonoBehaviour
{
    private GameObject r8;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name[0] != '0') {  r8 = GameObject.Find((Char.GetNumericValue(this.name[0]) - 1) + "R8" + this.name.Substring(3, this.name.Length - 3));}
       
        //add movement 
    }

    // Update is called once per frame
    void Update()
    {
        //check for condition to stop movent
        //delete movement
        if (this.name[0] != '0')
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(0.5f* new Vector2((r8.transform.GetChild(28).transform.position.x) - (this.transform.GetChild(28).transform.position.x),
                   (r8.transform.GetChild(28).transform.position.y) - (this.transform.GetChild(28).transform.position.y)).normalized);
        }
    }
}
