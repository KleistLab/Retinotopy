using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueControl : MonoBehaviour
{
   

    //spawner
    private GameObject spawner;
    private bool glue;
    void Start()
    {
        
        spawner = GameObject.FindGameObjectWithTag("spawner");

        glue = spawner.GetComponent<Parameters>().GLUE;
        //fmi_mut_list=spawner.GetComponent<Parameters>().fmi_mut;
        if (glue)
        {//fmi_mut_list.Contains(this.name)

            foreach (Transform child in this.transform)
            {
                Glue glues = child.GetComponent<Glue>();






                if (glues != null)//if mutant keep off
                {
                    glues.enabled = true;


                }


            }


          


        }
        else
        {


            foreach (Transform child in this.transform)
            {
                Glue glues = child.GetComponent<Glue>();






                if (glues != null)//if mutant keep off
                {
                    glues.enabled = false;


                }


            }


        }


    }
    // Update is called once per frame
    void Update()
    {
    }

}
