using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public int maxjoint = 1;
  
    //spawner object
    private GameObject spawner;
    //string where decay time comb is stored
    private string wave; //0-3
    //current status of the waves
    private bool[] waves_status = { false, false, false, false };
    //store the string char as number for each case
    private int c1, c2, c3, c4;
    private char myname;


    public bool fmi = true;
    // Start is called before the first frame update
    void Start()
    {
        myname = gameObject.name[2];
        maxjoint = +3;
      

        spawner = GameObject.FindGameObjectWithTag("spawner");
        wave = spawner.GetComponent<Parameters>().decay_time;
        waves_status[3] = false; //no decay
        c1 = Convert.ToInt32(Char.GetNumericValue(wave[0]));
        c2 = Convert.ToInt32(Char.GetNumericValue(wave[1]));
        c3 = Convert.ToInt32(Char.GetNumericValue(wave[2]));
    }

    // Update is called once per frame
    void Update()
    {
        //checks conditions
        waves_status[0] = (GameObject.Find(this.name[0] + "R30") != null);   // 34 spawn
        waves_status[1] = (GameObject.Find(this.name[0] + "R10") != null); // 16 spawn
        if (GameObject.Find(this.name[0] + "R10") != null) { waves_status[2] = IsGrown(GameObject.Find(this.name[0] + "R10")); }//waves_status[2]= 16 grown
         //Debug.Log(this.name[0] + "R10");
        if (waves_status[c1] && myname == '2') //r2
        {
            fmi= false;
        }
        else if (waves_status[c2] && myname == '5') //r5
        {
            fmi = false;

        }
        else if (waves_status[c3] && myname == '8')//r8
        {
            fmi = false;
        }

    }

    public bool IsGrown(GameObject o)
    {

        if (o == null) { return false; }
        if (o.transform.parent.gameObject.transform.localScale.x < 1) { return false; }

        
        return true;
    }
}
