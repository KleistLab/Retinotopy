using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdkState : MonoBehaviour
{
    public int maxjoint = 1;

    //spawner object
    private GameObject spawner;

    private char myname;


    public bool sdk = true;
    // Start is called before the first frame update
    void Start()
    {
        myname = gameObject.name[2];
        maxjoint = +3;


        spawner = GameObject.FindGameObjectWithTag("spawner");
        
        //if()
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public bool IsGrown(GameObject o)
    {

        if (o == null) { return false; }
        if (o.transform.parent.gameObject.transform.localScale.x < 1) { return false; }


        return true;
    }
}
