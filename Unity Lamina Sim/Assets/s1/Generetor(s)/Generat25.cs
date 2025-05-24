using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Generat25 : MonoBehaviour
{
    //prefabs, get from Object Viewer Drag Down
    public GameObject R2,R5;
    //internal objects
    private GameObject r2,r5,spawner;
    //ini pos of r2 and r5
    private Vector3 position2,position5,cc_line ;
    private float height,cc2,cc5;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner");
        //initiate positions as positions of this r8
        position2 = this.transform.GetChild(24).transform.position;
        position2.y = position2.y + 0.65f;  //28 for norm straight
        position2.x = position2.x - 0.05f;

        position5 = this.transform.GetChild(6).transform.position; //0,13
        position5.y = position5.y  - 0.6f;
        position5.x = position5.x + 0.2f;

        if (spawner.GetComponent<Parameters>().Equator&& ((spawner.GetComponent<Generat8>().equator[0]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
        {
            position2 = this.transform.GetChild(2).transform.position;
            position2.y = position2.y + 0.65f;  //28 for norm straight
            position2.x = position2.x + 0.05f;

            position5 = this.transform.GetChild(21).transform.position;
            position5.y = position5.y - 0.6f;
            position5.x = position5.x - 0.2f;
        }
        height = spawner.GetComponent<Parameters>().cc_height;
        cc2 = spawner.GetComponent<Parameters>().cc2;
        cc5 = spawner.GetComponent<Parameters>().cc5;
    }

    // Update is called once per frame
    void Update()
    {
        //determine between to spawning methods - linear or with a spawn line (cluster aproach)
        if (spawner.GetComponent<Parameters>().cc_mode) {
            cc_line = (spawner.GetComponent<Parameters>().cc - this.transform.GetChild(transform.childCount - 1).transform.position).normalized;
           // Debug.Log(cc_line);


            //r2
            //adjust postion
            //create
            //rename itself + bones
            position2 = position2 + (this.transform.localScale.y + cc2)*cc_line;
            r2 = Instantiate(R2, position2, Quaternion.identity);
            r2.name = this.name.Substring(0, 1) + r2.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r2.transform)
            {
                t.gameObject.name = r2.name;
            }
            //r5
            //adjust postion
            //create
            //rename itself + bones
            position5 = position5 - (this.transform.localScale.y + cc5) * cc_line;
            r5 = Instantiate(R5, position5, Quaternion.identity);
            r5.name = this.name.Substring(0, 1) + r5.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r5.transform)
            {
                t.gameObject.name = r5.name;
            }

        } 
        else {
            //r

            //create
            //rename itself + bones
            //this.transform.localScale.y+
            r2 = Instantiate(R2, position2, Quaternion.identity);
            r2.name = this.name.Substring(0,1) + r2.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r2.transform)
            {
                t.gameObject.name = r2.name;
            }
            //string path = "Assets/Resources/angle.txt";
            ////Write some text to the test.txt file
            //StreamWriter writer = new StreamWriter(path, true);
            //writer.WriteLine(r2.name + " " + r2.tag + " " + r2.transform.position);
            
            //r5
            //adjust postion
            //create
            //rename itself + bones
            //- this.transform.localScale.y
            r5=Instantiate(R5, position5, Quaternion.identity);
            r5.name = this.name.Substring(0, 1) + r5.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r5.transform)
            {
                t.gameObject.name = r5.name;
            }
            //writer.WriteLine(r5.name + " " + r5.tag + " " + r5.transform.position);
            //writer.Close();
        }

        if (spawner.GetComponent<Parameters>().cc_mode && this.name.Substring(3, this.name.Length - 3) == "1") {     
         //move cc point higher
        spawner.GetComponent<Parameters>().cc.y += height/2;
        
        }
        //disable (only run once)
        this.enabled = false;

    }
}
