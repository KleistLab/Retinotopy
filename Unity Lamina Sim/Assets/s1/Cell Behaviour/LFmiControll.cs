using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LFmiControll : MonoBehaviour
{
    // chosen time and its status
    private int time;
    private bool timewave;

    //spawner
    private GameObject spawner;
    private bool mode,cc_mode;
    private string[] fmi_mut_list;
    private bool fmi;
    private bool fmi_sparse;
    void Start()
    {
        //time --> from spawner param
        spawner = GameObject.FindGameObjectWithTag("spawner");

        mode = spawner.GetComponent<Parameters>().mode;
        cc_mode = spawner.GetComponent<Parameters>().cc_mode;
        fmi = spawner.GetComponent<Parameters>().fmi;
        fmi_sparse = spawner.GetComponent<Parameters>().fmi;
        fmi_mut_list=spawner.GetComponent<Parameters>().fmi_mut;
        if (fmi) {//fmi_mut_list.Contains(this.name)

            foreach (Transform child in this.transform)
            {
                EarlyFlamingo zfmi = child.GetComponent<EarlyFlamingo>();
                LateFlamingo lfmi = child.GetComponent<LateFlamingo>();
               



                  
                    if (zfmi != null )//if mutant keep off
                    {
                        zfmi.enabled = false;
                        this.GetComponent<State>().fmi=false;

                    }
                    if (lfmi != null)
                {
                    lfmi.enabled = false;
                }
                
           
            }
            

            //Debug.Log("I am mutant now "+this.name);


        }
        else if (fmi_sparse & fmi_mut_list.Contains(this.name))
        {

            foreach (Transform child in this.transform)
            {
                EarlyFlamingo zfmi = child.GetComponent<EarlyFlamingo>();
                LateFlamingo lfmi = child.GetComponent<LateFlamingo>();





                if (zfmi != null)//if mutant keep off
                {
                    zfmi.enabled = false;
                    this.GetComponent<State>().fmi = false;

                }
                if (lfmi != null)
                {
                    lfmi.enabled = false;
                }


            }


           // Debug.Log("I am mutant now " + this.name);


        }
        else {
            //Debug.Log("I am NOT a mutant  " + this.name);

            //switch between all fmi and case fmi
            foreach (Transform child in this.transform)
            {
                EarlyFlamingo zfmi = child.GetComponent<EarlyFlamingo>();
                LateFlamingo lfmi = child.GetComponent<LateFlamingo>();
                //
              

                //}else
                if (zfmi != null)//if mutant keep off
                {
                    zfmi.enabled = true;


                }
            }

 

            time = spawner.GetComponent<Parameters>().fmi_time;
          
            //if not chosen continous --> disable LateFmi
            if (time != 0)
            {
                foreach (Transform child in this.transform)
                {
                    LateFlamingo lfmi = child.GetComponent<LateFlamingo>();

                    if (lfmi != null)
                    {
                        lfmi.enabled = false;
                    }
                }
            }
            else if (time == 0)
            {

                foreach (Transform child in this.transform)
                {
                    LateFlamingo lfmi = child.GetComponent<LateFlamingo>();

                    if (lfmi != null)
                    {
                        lfmi.enabled = true;
                    }
                }
            }

            //status of timewave is false in the beginning
            timewave = false;

        }
          

    }
    // Update is called once per frame
    void Update()
    {
        if (fmi != true) {
        //update status of chosen timepoint
        if (time == 1)
        {
            //on 1-6 fullgrow
             
            if (GameObject.Find(this.name[0] + "R10") != null)
            {
                timewave = IsGrown(GameObject.Find(this.name[0] + "R10"));
            }

        }
        else if (time == 2)
        {
            //on next 1-6 spawn
            timewave = (GameObject.Find((Char.GetNumericValue(this.name[0]) + 1) + "R10") != null);

        }
        else if (time == 3)
        {
            //on next 1-6 fullgrow   
            if (GameObject.Find((Char.GetNumericValue(this.name[0]) + 1) + "R10") != null)
            {
                timewave = IsGrown(GameObject.Find((Char.GetNumericValue(this.name[0]) + 1) + "R10"));
            }
        }

        //if the chosen timewave active --> enable Late Fmi
        if (timewave)
        {
            foreach (Transform child in this.transform)
            {
                LateFlamingo lfmi = child.GetComponent<LateFlamingo>();
                EarlyFlamingo zfmi = child.GetComponent<EarlyFlamingo>();

                if (lfmi != null&& zfmi!=null)
                {
                    lfmi.enabled = true;
                    //zfmi.enabled = false;
                }
            }
            this.GetComponent<LFmiControll>().enabled = false;
        } }
    }

    //check if grown func
    public bool IsGrown(GameObject o)
    {

        if (o == null) { return false; }
       
        if (o.transform.parent.gameObject.transform.localScale.x < 0.2f) { return false; }
         

        return true;
    }
}
