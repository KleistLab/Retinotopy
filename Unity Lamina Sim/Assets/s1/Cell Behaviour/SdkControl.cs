using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdkControl : MonoBehaviour
{
    // chosen time and its status
    private int time;
    private bool timewave;

    //spawner
    private GameObject spawner;
    private bool mode, cc_mode;
    private string[] sdk_mut_list;
    private bool sdk;
    void Start()
    {
        
        spawner = GameObject.FindGameObjectWithTag("spawner");

        mode = spawner.GetComponent<Parameters>().mode;
        cc_mode = spawner.GetComponent<Parameters>().cc_mode;
        sdk = spawner.GetComponent<Parameters>().sdk;
        //fmi_mut_list=spawner.GetComponent<Parameters>().fmi_mut;
        if (sdk)
        {//fmi_mut_list.Contains(this.name)

            foreach (Transform child in this.transform)
            {
                Sidekick sdks = child.GetComponent<Sidekick>();






                if (sdks != null)//if mutant keep off
                {
                    sdks.enabled = false;


                }


            }


           // Debug.Log("I am sdk mutant now " + this.name);


        }
        else
        {


            foreach (Transform child in this.transform)
            {
                Sidekick sdks = child.GetComponent<Sidekick>();






                if (sdks != null)//if mutant keep off
                {
                    sdks.enabled = true;


                }


            }


        }


    }
    // Update is called once per frame
    void Update()
    {
    }


}
