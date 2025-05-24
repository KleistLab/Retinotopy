
using System;
using System.Data;

using UnityEngine;



public class Generat8 : MonoBehaviour
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
    private float zz_factor = 0;
    private float height;
    [HideInInspector] public int[] equator;
    private int rows;

    // Start is called before the first frame update
    // because it is the initial spawner script 
    // it creates a row of r8s in the beginning amd the rest
    // is spawned by later cell objects
    void Start()
    {
        if (this.GetComponent<Parameters>().mode) { zz_factor = this.GetComponent<Parameters>().zz_factor; }
        zigzag = this.GetComponent<Parameters>().zigzag;
        amount = this.GetComponent<Parameters>().amount;
        height = this.GetComponent<Parameters>().cc_height;
        rows = this.GetComponent<Parameters>().rows;       //for the amount of wanted r8s
        // create
        // rename object + children
        // move to next spawning position
        //position constellation is according to mode
        //TODO
        //MAKE ZIGZAG EXTREMER

        //wait untill eq full
        if (this.GetComponent<Parameters>().Equator)
        {
            equator = new int[rows];
            //EQUATOR
            // bundel num/2 high chance of turning 
            //example 10 bund 5th 70% 6th 85% 7th 100% rest 
            //70+(15*(i-midnum)
            // calculate turning bundle fpr each row beforehand --> apply then
            // if cell is turned --> mirror 1-3 4-6
            // R3- 9 ->19
            // R4- 4 ->25
            // R1- 20 ->8
            // R6- 20 ->8
            for (int i = 0; i < rows; i++)
            {
                for (int j = amount / 2; j < amount; j++)
                {
                    int chance = Mathf.Min(100 + (20 * (j - (amount / 2))), 100);
                    //Debug.Log("Chance:" +chance);
                    if (UnityEngine.Random.Range(1, 100) <= chance)
                    {
                        equator[i] = j;
                        //Debug.Log("Equator:"+equator[i]+" "+i);

                        break;
                    }


                }

            }
        }

        for (int c = 0; c < amount; c++) //amount of wanted r8s
        {
            r8=Instantiate(prefab, position, Quaternion.identity);
            r8.name =0+ r8.tag + c;
            foreach (Transform t in r8.transform)
            {
                t.gameObject.name = r8.name;
            }
            if (this.GetComponent<Parameters>().mode) 
            {

                if (this.GetComponent<Parameters>().Equator && ((equator[0]) < (c+1)))
                {
                    if ((c % 2 == 1))
                    {
                        position.y = position.y + 2.2f;
                        position.x = position.x + 2.8f;
                    }
                    else
                    {

                        position.y = position.y - 2.2f;
                        position.x = position.x + 1.5f;
                    }

                }
                else if (this.GetComponent<Parameters>().Equator && ((equator[0]) == (c+1)))
                {
                    position.x = position.x + 2.8f;

                }
                else
                {
                    if ((c % 2 == 0))
                    {
                        position.y = position.y + 2.2f;
                        position.x = position.x + 1.5f;
                    }
                    else
                    {

                        position.y = position.y - 2.2f;
                        position.x = position.x + 2.8f;
                    }
                }
            }
            else {           
                if (this.GetComponent<Parameters>().cc_mode)
                {
                position.x = position.x +0.01f+ 2 * r8.GetComponent<Growth>().maxRadius;
                }
                else { position.x = position.x + 2;}
                
                if(zigzag && (c % 2 == 0)) { position.y = position.y + 0.01f+zz_factor +  2*r8.GetComponent<Growth>().maxRadius; }
                else if (zigzag){ position.y = position.y - 0.01f-zz_factor - 2 * r8.GetComponent<Growth>().maxRadius; } 
            }

        }
        
        //if cluster mode is active, determine center of cluster spawnlines
        if (this.GetComponent <Parameters>().cc_mode) {
        position.x= (position.x)/2;
        position.y = height;
        this.GetComponent<Parameters>().cc = position; }
        
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

