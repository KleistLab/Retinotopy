using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generat8mov : MonoBehaviour
{
    //amount of cells in one row  -> i.e. determines the number of bundels 
    private bool zigzag;
    //amount of cells in one row  -> i.e. determines the number of bundels 
    private int amount;
    //prefab, get from Object Viewer Drag Down
    public GameObject prefab;
    //internal r8 object which is later intiated
    private GameObject r8;
    //initial spawning position
    private Vector3 position = new Vector3(0, 0, 0);
    
    private float height;
    private int index;
    private GameObject spawn;
    private int i =0;

    // Start is called before the first frame update
    // because it is the initial spawner script 
    // it creates a row of r8s in the beginning amd the rest
    // is spawned by later cell objects
    void Start()
    {
        
        //if (this.GetComponent<Parameters>().mode) { zz_factor = this.GetComponent<Parameters>().zz_factor; }
        zigzag = this.GetComponent<Parameters>().zigzag;
        amount = this.GetComponent<Parameters>().amount;
       // if i am not an r8 --> 0 in the name
       // if i am r8 --> my index +1

        //if 0 --> inni spawn
        // if i --> + ix up 
        // add vector to move down by the same rate as it growths 
        // when grown should tuc in like a puzzle

        //for the amount of wanted r8s
        // create
        // rename object + children
        // move to next spawning position
        //position constellation is according to mode
      
            for (int c = 0; c < amount; c++) //amount of wanted r8s
            {
                r8 = Instantiate(prefab, position, Quaternion.identity);
                r8.name = i + "R8" + c;
                foreach (Transform t in r8.transform)
                {
                    t.gameObject.name = r8.name;
                }

                    position.x = position.x + 0.01f + 2 * r8.GetComponent<Growth>().maxRadius;

                if (zigzag && (c % 2 == 0)) { position.y = position.y + 0.01f + 2 * r8.GetComponent<Growth>().maxRadius; }
                else if (zigzag) { position.y = position.y - 0.01f - 2 * r8.GetComponent<Growth>().maxRadius; }
            }
       
       

        //if cluster mode is active, determine center of cluster spawnlines
       

    }

    // Update is called once per frame
    void Update()
    {


        // Debug.Log(count_rows);

        //junk which didnt work
        ////if r8s and r2s are grown

        //if (grown){
        //   grown = false;
        //    r2s = null;
        //    // find r2 with left-high most tag [0] rowc [3] 0
        //    r2 = GameObject.Find(rowc + "R2"+ "0");
        //    //
        //    // grow r8 
        //    rowc += 1;
        //    position = r2.transform.position;
        //    position.y = position.y + r2.transform.localScale.y * 2;
        //    for (int c = 0; c < amount; c++) //amount of wanted r8s
        //    {
        //        r8 = Instantiate(prefab, position, Quaternion.identity);
        //        r8.name = (rowc )+ r8.tag + c;
        //        foreach (Transform t in r8.transform)
        //        {
        //            t.gameObject.name = r8.name;
        //        }
        //        position.x = position.x + r2.transform.localScale.x * 2;
        //    }

        // }

    }

}
