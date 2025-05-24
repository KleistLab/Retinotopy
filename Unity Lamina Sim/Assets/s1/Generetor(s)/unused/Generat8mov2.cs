using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;



public class Generat8mov2 : MonoBehaviour
{
    //number of rows wanted (rows = intial row +x)
    private int rows;
    // prefab for r8 
    private GameObject prefab;
    // r8 is the new spaned r8, r2 is the adjescent r2 to current r8 and spawner is the initial element
    private GameObject r8,r8n, spawner;
    // arrat of all r2s
    private GameObject[] r2s;
    // once spawned cycle is finisched and thus false, grown checks whether the r2s are already grown
    private bool cycle, grown;
    //position where the new r8 has to be spawned
    private Vector3 position;
    private ConstantForce2D force2d;
    private float str;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner");
        //get param from spawner
        rows = spawner.GetComponent<Parameters>().rows;
        str = spawner.GetComponent<Parameters>().mov_str;
        //get prefab
        prefab = Resources.Load<GameObject>("R8");

        //before run cycle is true -> not yet done
        cycle = true;

        

    }

    // Update is called once per frame
    void Update()
    {
        //only do this once. hence the cycle var
        if (cycle)
        {

            //find all r2s
            //TODO:
            // find only recent R2, cause previous ones are grown
            r2s = GameObject.FindGameObjectsWithTag("R2");//new GameObject[] { this.gameObject };
            //if some r2s found check for growth
            if (r2s.Length > 0) { grown = AreGrown(r2s); }
            //if the r2s are grown and current index is under the row limit spawn new r8
            if (grown && Char.GetNumericValue(this.name[0]) < rows - 1)
            {
                //find adjascent r2
                r8 = GameObject.Find(this.name[0] + "R8" + this.name.Substring(3, this.name.Length - 3));

                //take position of last child (middle bone) because parents pos doesent change ;( 
                //if cc mode is on determine position on spawnline
                // and relocate to above the r2 with some free toleration space inbetween
                position = r8.transform.position;

               
                    position.y = position.y +  7 ;
                
                //create new r8 and rename it and all the bones
                r8n = Instantiate(prefab, position, Quaternion.identity);
                r8n.name = (Char.GetNumericValue(this.name[0]) + 1) + r8.tag + this.name.Substring(3, this.name.Length - 3);
                //vector richtung R8x d.h this posisch - r8.lastchid poisch
                foreach (Transform t in r8n.transform)
                {
                    t.gameObject.name = r8n.name; 
                    t.GetComponent<Rigidbody2D>().AddForce(str*((r8.transform.GetChild(28).transform.position)-(t.transform.position)).normalized);
                }
                // movemnet vektr 
                //maybe apply to child???is this any better?
                //r8.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                //r8.gameObject.GetComponent<Rigidbody2D>().AddForce(3*new Vector2((this.transform.GetChild(28).transform.position.x) - (r8.transform.GetChild(28).transform.position.x),
                //        (this.transform.GetChild(28).transform.position.y) - (r8.transform.GetChild(28).transform.position.y)).normalized);
                //Debug.Log(cycle);
           
                //set ther cycle to false to ensure that the script only runs once
                cycle = false;

              
            }
            

        }
        //if bla? --> get r2/r5s from the r8 object row --. if x stop moving
        //remove forces from r8 
        //if (r8?.transform.localScale[0] >= 0.2f)
        //{

        //    foreach (Transform t in r8.transform)
        //    {
        //        t.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //        t.GetComponent<Rigidbody2D>().angularVelocity = 0;
                
        //    }
        //}

    }

    bool AreGrown(GameObject[] os)
    {
        foreach (GameObject o in os)
        {

            if (o.transform.localScale.x <= 0.5) { return false; }

        }


        return true;
    }

}
