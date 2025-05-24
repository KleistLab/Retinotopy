using System;
using System.Collections;

using UnityEngine;

public class Generat46 : MonoBehaviour
{
    ////prefabs of r1 and r3
    //public GameObject prefab4;
    //public GameObject prefab6;
    //public GameObject spacer;
    ////internal r1 and r3 objects
    //private GameObject r4, r6, s;
    ////spawner
    //private GameObject spawner;

    ////spawn r3 and r1 only once, hence cycle bool
    //private bool cycle_r4 = true;
    //private bool cycle_r6 = true;
    //private bool timewave = false;
    ////spawning position of new r1 r1 objects 
    //private Vector3 position;

    ////get this params from spawner
    //private int place4, place6;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    //find spawner and get params
    //    spawner = GameObject.FindGameObjectWithTag("spawner");
    //    if (spawner.GetComponent<Parameters>().Equator) { 
    //        if ((spawner.GetComponent<Parameters>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3))))
    //        {

    //            place4 = 24;
    //            place6= 8;
    //            //turned = true;

    //            //Debug.Log(turned + " " + this.name);
    //        }
    //        else
    //        {
    //            place4 = spawner.GetComponent<Parameters>().spawnplace_34[1];
    //            place6 = spawner.GetComponent<Parameters>().spawnplace_16[1];
    //        }

    //    }
    //    else
    //    {
    //        place4 = spawner.GetComponent<Parameters>().spawnplace_34[1];
    //        place6 = spawner.GetComponent<Parameters>().spawnplace_16[1];
    //    }

        

    //    //start spawning coroutine
    //    StartCoroutine(Spawn());

    //}

    
    //// code from stackoverflow with changes to bounds to function type
    ////https://stackoverflow.com/questions/18874950/function-for-finding-an-empty-space-in-an-area-how-to-return-an-error-if-none-i
    //private Vector3 CheckForEmptySpace(Vector3 pos)
    //{
    //    float[] bounds = { pos.x - 0.05f, pos.y - 0.05f, pos.x + 0.05f, pos.y + 0.05f };
    //    var sphereRadius = 0.01f;
    //    var startingPos = pos;
    //    // Loop, until empty adjacent space is found
    //    var spawnPos = startingPos;
    //    while (true)
    //    {
    //        if (!Physics.CheckSphere(spawnPos, sphereRadius))   // Check if area is empty
    //            return spawnPos;    // Return location
    //        else
    //        {
    //            // Not empty, so gradually move position down. If we hit the boundary edge, move and start again from the opposite edge.
    //            var shiftAmount = 0.001f;
    //            spawnPos.y -= shiftAmount;
    //            if (spawnPos.y < bounds[1])//min y
    //            {
    //                spawnPos.y = bounds[3];//max y
    //                spawnPos.x += shiftAmount;
    //                if (spawnPos.x > bounds[2])//max x
    //                    spawnPos.x = bounds[0];//min x
    //            }
    //            // If we reach back to a close radius of the starting point, then we didn't find any empty spots
    //            var proximity = (spawnPos - startingPos).sqrMagnitude;
    //            var range = shiftAmount - 0.0005f;    // Slight 0.1 buffer so it ignores our initial proximity to the start point
    //            if (proximity < range * range)  // Square the range
    //            {
    //                Debug.Log("An empty location could not be found");
    //                return pos;
    //            }
    //        }
    //    }
    //}
    //public IEnumerator Spawn()
    //{
        
    //    //first r4
    //    if (cycle_r4)
    //    {
    //        //take position of x child 
    //        //and check for  avaible free space next to it, return it

    //        //position = this.transform.GetChild(place4).transform.position;

    //        ////check for empty space mit CheckForEmptySpace()
    //        //position = CheckForEmptySpace(position);

    //        ////spacer for make sure new object has space to grow
    //        //s = Instantiate(spacer, position, Quaternion.identity);
    //        //yield return new WaitForSeconds(1);

    //        ////spawn object and delete spacer
    //        //r4 = Instantiate(prefab4, position, Quaternion.identity);
    //        //Destroy(s);

    //        ////rename r3 object and its bones 
    //        //r4.name = this.name[0] + r4.tag + this.name.Substring(3, this.name.Length - 3);
    //        //foreach (Transform t in r4.transform)
    //        //{
    //        //    t.gameObject.name = r4.name;
    //        //}
    //        //set to false because spawned once, cycle done
    //        cycle_r4 = false;
    //    }
    //    if (GameObject.Find(this.name[0] + "R40") != null)
    //    {
    //        r4 = GameObject.Find(this.name[0] + "R40");
    //        timewave = IsGrown(r4);
    //    }
    //    while ((cycle_r6 &&timewave) == false)//spawning r6 after r4 has grown
    //    {
    //        Debug.Log(r4.tag);
    //     timewave = IsGrown(r4);
           
    //        yield return null;
    //    }
    //    //take position of x child 
    //    //and check for  avaible free space next to it, return it
    //    position = this.transform.GetChild(place6).transform.position;

    //    //check for empty space with CheckForEmptySpace()
    //    position = CheckForEmptySpace(position);

    //    //spacer for make sure new object has space to grow
    //    s = Instantiate(spacer, position, Quaternion.identity);
    //    yield return new WaitForSeconds(1.5f);

    //    //spawn object and delete spacer
    //    r6 = Instantiate(prefab6, position, Quaternion.identity);
    //    Destroy(s);

    //    //rename r3 object and its bones 
    //    r6.name = this.name[0] + r6.tag + this.name.Substring(3, this.name.Length - 3);
    //    foreach (Transform t in r6.transform)
    //    {
    //        t.gameObject.name = r6.name;
    //    }
    //    //set to false because spawned once, cycle done
    //    cycle_r6 = false;
        

    //}

    //public bool IsGrown(GameObject o)
    //{

    //    if (o == null) { return false; }

    //    if (o.transform.parent.gameObject.transform.localScale.x < 1) { return false; }


    //    return true;
    //}
}
