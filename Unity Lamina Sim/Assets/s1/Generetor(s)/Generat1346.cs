using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
using UnityEngine.UIElements;

public class Generat1346 : MonoBehaviour
{
    //prefabs of r1 and r3
    public GameObject prefab3;
    public GameObject prefab1;
    public GameObject prefab4, prefab6;
    public GameObject spacer;
    //internal r1 and r3 objects
    private GameObject r3,r1,s,r4,r6;
    //spawneer
    private GameObject spawner;

    //spawn r3 and r1 only once, hence cycle bool
    private bool cycle_r3 =true;
    private bool cycle_r1 = true;
   
    //spawning position of new r1 r1 objects 
    private Vector3 position, position5,position4;

    //get this params from spawner
    private int place1, place3,place4,place6;
    private string[][] rot;
    private bool sdk;


    private bool fmi;
    private string[] fmi_rot;
    private int amount;
    private int[] sdk_mut_num3,sdk_mut_num4 ;
    // Start is called before the first frame update
    void Start()
    {
        //sdk mutants pattern
        sdk_mut_num3 = new int[] {1, 1, 0, 2, 1, 1, 1, 2, 0, 1,
                                1, 1, 1, 1, 1, 0, 2, 1, 1, 1,
                                1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                                1, 2, 0, 1, 1, 1, 1, 1, 0, 2,
                                1, 1, 1, 1, 1, 1, 1, 0, 2, 1 } ;
        sdk_mut_num4 = new int[] {1, 1, 1, 1, 2, 0, 1, 1, 1, 1,
                                1, 0, 2, 1, 1, 1, 1, 1, 1, 1,
                                1, 1, 1, 1, 1, 0, 2, 1, 1, 1,
                                1, 1, 1, 1, 0, 2, 1, 1, 1, 1,
                                1, 1, 2, 0, 1, 0, 2, 1, 1, 1 };
        //find spawner and get params
        spawner = GameObject.FindGameObjectWithTag("spawner");
        sdk = spawner.GetComponent<Parameters>().sdk;
        //if (sdk) { Random.InitState(42); }
        //Debug.Log(spawner.GetComponent<Parameters>().equator[0] + " " + this.name[0]);
        if (spawner.GetComponent<Parameters>().Equator)
        {
            if ((spawner.GetComponent<Generat8>().equator[0]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3))))
            {

                place3 = 18;
                place1 = 6;
                place6 = 6;
                //turned = true;

                //Debug.Log(turned + " " + this.name);
            }
            else
            {
                place3 = spawner.GetComponent<Parameters>().spawnplace_34[0];
                place4 = spawner.GetComponent<Parameters>().spawnplace_34[1];
                place1 = spawner.GetComponent<Parameters>().spawnplace_16[0];
                place6 = spawner.GetComponent<Parameters>().spawnplace_16[1];
            }
        }
        else
        {
            place3 = spawner.GetComponent<Parameters>().spawnplace_34[0];
            place4 = spawner.GetComponent<Parameters>().spawnplace_34[1];
            place1 = spawner.GetComponent<Parameters>().spawnplace_16[0];
            place6 = spawner.GetComponent<Parameters>().spawnplace_16[1];
        }


        fmi = spawner.GetComponent<Parameters>().fmi;
        fmi_rot = spawner.GetComponent<Parameters>().fmi_rot_mut;
        amount = spawner.GetComponent<Parameters>().amount;
        if (fmi)
        {
            int me = (int)(Char.GetNumericValue(this.name[0]) * amount + Char.GetNumericValue(this.name[3]));
            
            if (fmi_rot[me] == "1"|| fmi_rot[me] == "2"|| fmi_rot[me] == "3")
            {
                place3 = spawner.GetComponent<Parameters>().spawnplace_34[0];
                place4 = spawner.GetComponent<Parameters>().spawnplace_34[1];
                place1 = spawner.GetComponent<Parameters>().spawnplace_16[0];
                place6 = spawner.GetComponent<Parameters>().spawnplace_16[1];
            }

            else if (fmi_rot[me] == "4")
            {

                //120

                place3 = 15;
                place1 = 1;
                place6 = 1;

            }
            else if (fmi_rot[me] == "5")
            {
                //180

                place3 = 22;
                place1 = 6;
                place6 = 6;

            }

        }




        //if sdk mutant --> shake around (even choose another bundle)
        rot = spawner.GetComponent<Parameters>().rot_mut;
        if (rot != null)
        {
            if (rot[0][0] == this.name[0].ToString() && rot[0][1] == this.name.Substring(3))
            {   //30,60,90deg mutant
                //place3 = spawner.GetComponent<Parameters>().spawnplace_34[0];
                //place4 = spawner.GetComponent<Parameters>().spawnplace_34[1];
                //place1 = spawner.GetComponent<Parameters>().spawnplace_16[0];
                //place6 = spawner.GetComponent<Parameters>().spawnplace_16[1];

                //120deg mutant 
                //place3 = 15;
                //place1 = 1;
                //place6 = 1;

                //180
                //place3 = 22;
                //place1 = 6;
                //place6 = 6;



            }


        }   


        //spawning coroutine
        StartCoroutine(Spawn());
    }


// code from stackoverflow with changes to bounds to function type
//https://stackoverflow.com/questions/18874950/function-for-finding-an-empty-space-in-an-area-how-to-return-an-error-if-none-i

private Vector3 CheckForEmptySpace(Vector3 pos)
    {
        float[] bounds = { pos.x - 0.02f, pos.y - 0.02f, pos.x + 0.02f, pos.y + 0.02f };
        var sphereRadius = 0.01f;
        var startingPos = pos;
        // Loop, until empty adjacent space is found
        var spawnPos = startingPos;
        while (true)
        {
            if (!Physics.CheckSphere(spawnPos, sphereRadius))   // Check if area is empty
                return spawnPos;    // Return location
            else
            {
                // Not empty, so gradually move position down. If we hit the boundary edge, move and start again from the opposite edge.
                var shiftAmount = 0.001f;
                spawnPos.y -= shiftAmount;
                if (spawnPos.y < bounds[1])//min y
                {
                    spawnPos.y = bounds[3];//max y
                    spawnPos.x += shiftAmount;
                    if (spawnPos.x > bounds[2])//max x
                        spawnPos.x = bounds[0];//min x
                }
                // If we reach back to a close radius of the starting point, then we didn't find any empty spots
                var proximity = (spawnPos - startingPos).sqrMagnitude;
                var range = shiftAmount - 0.0005f;    // Slight  buffer so it ignores our initial proximity to the start point
                if (proximity < range * range)  // Square the range
                {
                    Debug.Log("An empty location could not be found");
                    return pos;
                }
            }
        }
    }
    public IEnumerator Spawn()
    {
        //first r3 spawn
        if (cycle_r3)
        {
     
            //take position of x child 
            //and check for  avaible free space next to it, return it

           

            //check for empty space with CheckForEmptySpace()
            // position = CheckForEmptySpace(position);

            //spacer for make sure new object has space to grow
            //s = Instantiate(spacer, position, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
            
            position = this.transform.GetChild(place3).transform.position;
            if (spawner.GetComponent<Parameters>().Equator && ((spawner.GetComponent<Generat8>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
            {

                position.x = position.x - 0.15f;



            }
            else
            {
                position.x = position.x + 0.3f;

            }
            if (rot[0][0] == this.name[0].ToString() && rot[0][1] == this.name.Substring(3))
            {
                //position.x = position.x - 0.4f; //90
                //position.y = position.y - 0.3f; //30
                //position.x = position.x -0.2f; //30
                //position.x = position.x - 0.3f; //60
                //position.y = position.y - 0.2f; //60

                //position.y = position.y - 0.4f; //90


                //120
                //position.x = position.x + 0.15f;
                //position.y = position.y - 0.3f;

                //180
                //position.x = position.x - 0.3f;
                
                
            }
            if (fmi)
            {
                int me = (int)(Char.GetNumericValue(this.name[0]) * amount + Char.GetNumericValue(this.name[3]));
                Debug.Log(me);
                if (fmi_rot[me] == "1")
                {

                    position.y = position.y - 0.45f; //30
                    position.x = position.x - 0.3f; //30

                }
                else if (fmi_rot[me] == "2")
                {

                    //60 

                    position.x = position.x - 0.3f; //60
                    position.y = position.y - 0.2f; //60
                }
                else if (fmi_rot[me] == "3")
                {

                    //90

                    position.x = position.x - 0.4f; //90
                    position.y = position.y - 0.4f; //90
                }
                else if (fmi_rot[me] == "4")
                {

                    //120

                    position.x = position.x + 0.15f;
                    position.y = position.y - 0.3f;


                }
                else if (fmi_rot[me] == "5")
                {
                    //180

                    position.x = position.x - 0.3f;
                }

            }

            position.y = position.y + 0.1f;
            //spawn object and delete spacer

            if (sdk)
            {
                position4 = position;
                int me = (int)(Char.GetNumericValue(this.name[0]) * amount + Char.GetNumericValue(this.name[3]));

                //r3/4 decide placementy i case of mutant
                if (sdk_mut_num3[me] == 0)
                {
                    if (sdk_mut_num3[me + 1] == 2)
                    {

                        GameObject neigh = null;
                        GameObject[] all_neigh = GameObject.FindGameObjectsWithTag("R2");  //Find all GameObjects with specific tag

                        foreach (GameObject go in all_neigh)  //iterate through all returned objects, and find the one with the correct name
                        {
                            if (go.name == this.name.Substring(0, 1) + "R2" + (Char.GetNumericValue(this.name[3]) + 1))
                            {
                                neigh = go;
                                break;
                            }
                        }
                        position = neigh.transform.GetChild(place3).transform.position;
                        position.x = position.x + Random.Range(-0.7f, 0.7f);
                        position.y = position.y + Random.Range(-0.7f, 0.7f);
                        r3 = Instantiate(prefab3, position, Quaternion.identity);

                    }
                    else
                    {


                        GameObject neigh = null;
                        GameObject[] all_neigh = GameObject.FindGameObjectsWithTag("R2");  //Find all GameObjects with specific tag

                        foreach (GameObject go in all_neigh)  //iterate through all returned objects, and find the one with the correct name
                        {
                            if (go.name == this.name.Substring(0, 1) + "R2" + (Char.GetNumericValue(this.name[3]) - 1))
                            {
                                neigh = go;
                                break;
                            }
                        }
                        position = neigh.transform.GetChild(place3).transform.position;
                        position.x = position.x + Random.Range(-0.7f, 0.7f);
                        position.y = position.y + Random.Range(-0.7f, 0.7f);
                        r3 = Instantiate(prefab3, position, Quaternion.identity);

                    }

                }
                else
                {
                    
                    position.x = position.x + Random.Range(-0.7f, 0.7f);
                    position.y = position.y + Random.Range(-0.7f, 0.7f);
                    r3 = Instantiate(prefab3, position, Quaternion.identity);
                }

            }
            else { r3 = Instantiate(prefab3, position, Quaternion.identity);
            position.y = position.y - 0.2f;
            }
                

            if (spawner.GetComponent<Parameters>().Equator && ((spawner.GetComponent<Generat8>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
            {
                
                position.x = position.x - 0.15f;



            }
            else
            {
                position.x = position.x + 0.15f;

            }
            if (rot[0][0] == this.name[0].ToString() && rot[0][1] == this.name.Substring(3))
            {
                //position.x = position.x + 0.15f; //30
                //position.x = position.x -0.3f; //240
                //position.x = position.x - 0.30f; //60
                //position.x = position.x - 0.55f; //90
                //position.y = position.y - 0.2f; //120
                //position.x = position.x - 0.4f;//120
                //position.y = position.y + 0.2f;//120
                //position.x = position.x - 0.3f;//180
                //position.y = position.y + 0.4f;//180
            }
            if (fmi)
            {
                int me = (int)(Char.GetNumericValue(this.name[0]) * amount + Char.GetNumericValue(this.name[3]));
                
                if (fmi_rot[me] == "1")
                {

                    position.x = position.x - 0.3f;

                }
                else if (fmi_rot[me] == "2")
                {

                    //60 
                    position.x = position.x - 0.30f;
                }
                else if (fmi_rot[me] == "3")
                {

                    //90

                    position.x = position.x - 0.7f;
                }
                else if (fmi_rot[me] == "4")
                {

                    //120

                    position.x = position.x - 0.4f;


                }
                else if (fmi_rot[me] == "5")
                {
                    //180

                    position.x = position.x - 0.3f;//180
                    position.y = position.y + 0.4f;//180
                }

            }
            if (sdk)
            {
                position = position4;
                int me = (int)(Char.GetNumericValue(this.name[0]) * amount + Char.GetNumericValue(this.name[3]));
                
                 if(sdk_mut_num4[me] == 0)
                {
                    if (sdk_mut_num4[me+1] == 2) {

                        GameObject neigh = null;
                        GameObject[] all_neigh = GameObject.FindGameObjectsWithTag("R2");  //Find all GameObjects with specific tag

                        foreach (GameObject go in all_neigh)  //iterate through all returned objects, and find the one with the correct name
                        {
                            if (go.name == this.name.Substring(0, 1) + "R2" + (Char.GetNumericValue(this.name[3]) + 1))
                            {
                                neigh = go;
                                break;
                            }
                        }
                        position = neigh.transform.GetChild(place3).transform.position;
                        position.x = position.x + Random.Range(-0.7f, 0.7f);
                        position.y = position.y + Random.Range(-0.7f, 0.7f);
                        r4 = Instantiate(prefab4, position, Quaternion.identity);

                    }
                    else
                    {


                        GameObject neigh = null;
                        GameObject[] all_neigh = GameObject.FindGameObjectsWithTag("R2");  //Find all GameObjects with specific tag

                        foreach (GameObject go in all_neigh)  //iterate through all returned objects, and find the one with the correct name
                        {
                            if (go.name == this.name.Substring(0, 1) + "R2" + (Char.GetNumericValue(this.name[3]) - 1))
                            {
                                neigh = go;
                                break;
                            }
                        }
                        position = neigh.transform.GetChild(place3).transform.position;
                        position.x = position.x + Random.Range(-0.7f, 0.7f);
                        position.y = position.y + Random.Range(-0.7f, 0.7f);
                        r4 = Instantiate(prefab4, position, Quaternion.identity);

                    }

                } else  {
                position.x = position.x + Random.Range(-0.7f, 0.7f);
                position.y = position.y + Random.Range(-0.7f, 0.7f); 
                    r4 = Instantiate(prefab4, position, Quaternion.identity); }

            }
            else { r4 = Instantiate(prefab4, position, Quaternion.identity);
             }
               

            r3.name = this.name[0] + r3.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r3.transform)
            {
                t.gameObject.name = r3.name;
            }
            r4.name = this.name[0] + r4.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r4.transform)
            {
                t.gameObject.name = r4.name;
            }
            //set to false because spawned once, cycle done
            cycle_r3 = false;
        }
        while ((cycle_r1 && r3.transform.localScale[0] >= r3.GetComponent<Growth>().maxRadius)==false) //spawning r1 after r3 has grown
        { 
            yield return null;
        }

        GameObject r5 = null;
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("R2");  //Find all GameObjects with specific tag

        foreach (GameObject go in taggedObjects)  //iterate through all returned objects, and find the one with the correct name
        {
            if (go.name == this.name.Substring(0, 1) + "R2" + this.name.Substring(3, this.name.Length - 3))
            {
                r5 = go;
                break;
            }
        }
        //take position of x child 
        //and check for  avaible free space next to it, return it
        position = this.transform.GetChild(place1).transform.position;
        position5=r5.transform.GetChild(place6).transform.position;
        //position5.x=position5.x+0.01f;

        //check for empty space with CheckForEmptySpace()
        //position = CheckForEmptySpace(position);

        //spacer for make sure new object has space to grow
        //s = Instantiate(spacer, position, Quaternion.identity);
        // yield return new WaitForSeconds(1.5f);

        //if (spawner.GetComponent<Parameters>().Equator && ((spawner.GetComponent<Generat8>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
        //{

        //    position.x = position.x + 0.15f;
        //    //position5.x = position.x + 0.01f;



        //}
        //else
        //{
        //    position.x = position.x - 0.15f;
        //   //position5.x = position.x - 0.0005f;


        //}
        //spawn object and delete spacer
        //if (rot[0][0] == this.name[0].ToString() && rot[0][1] == this.name.Substring(3))//90
        //{
        //    position = this.transform.GetChild(22).transform.position;
        //    position5 = r5.transform.GetChild(19).transform.position;
        //    position.x = position.x - 0.2f;
        //    position5.x = position.x - 0.15f;
        //}
        if (sdk)
        {
            //evtl turn into variable (the 1)
            position.x = position.x + Random.Range(-1f, 1f);

            position.y = position.y + Random.Range(-1f, 1f);

            position5.x = position5.x + Random.Range(-1f, 1f);

            position5.y = position5.y + Random.Range(-1f, 1f);
        }
        r1 = Instantiate(prefab1, position, Quaternion.identity);
        r6 = Instantiate(prefab6, position5, Quaternion.identity);
        //Destroy(s);

        //rename r1 object and its bones
        r1.name = this.name[0] + r1.tag + this.name.Substring(3, this.name.Length - 3);
        foreach (Transform t in r1.transform)
        {
            t.gameObject.name = r1.name;
        }
        r6.name = this.name[0] + r6.tag + this.name.Substring(3, this.name.Length - 3);
        foreach (Transform t in r6.transform)
        {
            t.gameObject.name = r6.name;
        }
        //set to false because spawned once, cycle done
        cycle_r1 = false;
       
    }
    }
