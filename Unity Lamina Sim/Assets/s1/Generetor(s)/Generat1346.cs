using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private Vector3 position, position5;

    //get this params from spawner
    private int place1, place3,place4,place6;

    // Start is called before the first frame update
    void Start()
    {
        //find spawner and get params
        spawner = GameObject.FindGameObjectWithTag("spawner");

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
            position.y = position.y + 0.1f;

            //spawn object and delete spacer
            r3 = Instantiate(prefab3, position, Quaternion.identity);
            position.y = position.y - 0.2f;
            

            if (spawner.GetComponent<Parameters>().Equator && ((spawner.GetComponent<Generat8>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
            {
                
                position.x = position.x - 0.15f;



            }
            else
            {
                position.x = position.x + 0.15f;

            }
            r4 = Instantiate(prefab4,position , Quaternion.identity);
            //Destroy(s);
            //rename r3 object and its bones 

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
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("R5");  //Find all GameObjects with specific tag

        foreach (GameObject go in taggedObjects)  //iterate through all returned objects, and find the one with the correct name
        {
            if (go.name == this.name.Substring(0, 1) + "R5" + this.name.Substring(3, this.name.Length - 3))
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
