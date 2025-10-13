using System;
using UnityEngine;

public class Generat82 : MonoBehaviour
{
    //number of rows wanted (rows = intial row +x)
    private int rows;
    // prefab for r8 
    private GameObject prefab; 
    // r8 is the new spaned r8, r2 is the adjescent r2 to current r8 and spawner is the initial element
    private GameObject r8,r2,r2n,spawner;
    // arrat of all r2s
    private GameObject[] r2s;
    // once spawned cycle is finisched and thus false, grown checks whether the r2s are already grown
    private bool cycle,grown;
    //position where the new r8 has to be spawned
    private Vector3 position,cc_line;
    private float zz = 0 ;
    private float height,cc8;

    // Start is called before the first frame update
    void Start()
    {   
        spawner = GameObject.FindGameObjectWithTag("spawner");
        //get param from spawner
        rows = spawner.GetComponent<Parameters>().rows;

        //get prefab
        prefab = Resources.Load<GameObject>("R8");
        
        //before run cycle is true -> not yet done
        cycle = true;

        height =  spawner.GetComponent<Parameters>().cc_height;
        cc8 = spawner.GetComponent<Parameters>().cc8;
        if (spawner.GetComponent<Parameters>().mode) { zz = spawner.GetComponent<Parameters>().zz_space;}
       
    }

    // Update is called once per frame
    void Update()
    {
        //only do this once. hence the cycle var
        if(cycle)
        {
            //find all r2s
            //TODO:
            // find only recent R2, cause previous ones are grown
            r2s = GameObject.FindGameObjectsWithTag("R2"); 
            //if some r2s found check for growth
            if ( r2s.Length>0) { grown = AreGrown(r2s); }
            //if the r2s are grown and current index is under the row limit spawn new r8
            if (grown && Char.GetNumericValue(this.name[0])< rows-1)
            {
                ////find adjascent r2
                //GameObject r2 = null;
                //GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("R5");  //Find all GameObjects with specific tag

                //foreach (GameObject go in taggedObjects)  //iterate through all returned objects, and find the one with the correct name
                //{
                //    if (go.name == this.name.Substring(0, 1) + "R5" + this.name.Substring(3, this.name.Length - 3))
                //    {
                //        r2 = go;
                //        break;
                //    }
                //}

                //take position of last child (middle bone) because parents pos doesent change ;( 
                //if cc mode is on determine position on spawnline
                // and relocate to above the r2 with some free toleration space inbetween
                position = this.transform.GetChild(transform.childCount - 1).transform.position; 
                
                if (spawner.GetComponent<Parameters>().cc_mode) 
                {
                   
                    cc_line=(spawner.GetComponent<Parameters>().cc - position).normalized;
                    position = position + (cc8 * cc_line);
                    position=CheckForEmptySpace(position);
                } 
                else if (spawner.GetComponent<Parameters>().mode) {



                    //if (Convert.ToInt32(Char.GetNumericValue(this.name[0])) % 2 == 0)
                    //{

                    //    //if me grade
                    //    position.y = position.y + 4.5f;
                    //    position.x = position.x + 4;
                    //}
                    //else
                    //{

                    //    position.y = position.y + 4.5f;
                    //    position.x = position.x - 2f;
                    //}







                    //if (Convert.ToInt32(Char.GetNumericValue(this.name[0])) % 2 == 0)
                    //{

                    //    //if me grade
                    //    position.y = position.y + 4.01f;
                    //    //position.x = position.x + 3;
                    //}
                    //else
                    //{

                    //    position.y = position.y + 4.01f;
                    //   // position.x = position.x - 4;

                    //}



                    //position.y = position.y + 4.35f;
                    //if (spawner.GetComponent<Parameters>().Equator && ((spawner.GetComponent<Generat8>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
                    //{ 
                    //    position.x = position.x + 0.6f;

                    //}
                    //else
                    //{
                    //    position.x = position.x - 0.4f;
                    //}
                    //position = CheckForEmptySpace(position);


                    if (spawner.GetComponent<Parameters>().Equator && ((spawner.GetComponent<Generat8>().equator[Convert.ToInt32(Char.GetNumericValue(this.name[0]))]) <= (Convert.ToInt32(this.name.Substring(3, this.name.Length - 3)))))
                    {
                        if (Convert.ToInt32(Char.GetNumericValue(this.name[0])) % 2 == 0)
                        {

                            //if me grade
                            position.y = position.y + 5.5f;
                            position.x = position.x + 2.2f;
                        }
                        else
                        {

                            position.y = position.y + 5.5f;
                            position.x = position.x - 2f;
                        }
                    }
                    else
                    {

                        //position.y = position.y + 4.9f;
                        //position.x = position.x + 3;
                        if (Convert.ToInt32(Char.GetNumericValue(this.name[0])) % 2 == 0)
                        {

                            //if me grade
                            position.y = position.y + 5.5f;
                            position.x = position.x + 2.2f;
                        }
                        else
                        {

                            position.y = position.y + 5.5f;
                            position.x = position.x - 2f;
                        }

                    }

                }
                    //else if (Convert.ToUInt16(this.name.Substring(3, this.name.Length - 3))!= (spawner.GetComponent<Parameters>().amount)-1)
                    //{

                    //    position.y = position.y + r2.transform.localScale.y * 2-0.01f + zz;
                    //    r2n = GameObject.Find(this.name[0] + "R2" + (Convert.ToUInt32(this.name.Substring(3, this.name.Length - 3)) - 1));
                    //    position.x = (position.x + r2n.transform.GetChild(transform.childCount - 1).transform.position.x)/2;
                    //}
                    else
                {

                    position.y = position.y + r2.transform.localScale.y * 2 - 0.01f + zz;

                    position.x = position.x + 0.8f;

                }
                //create new r8 and rename it and all the bones
                r8 = Instantiate(prefab, position, Quaternion.identity);
                    r8.name = (Char.GetNumericValue(this.name[0]) +1) + r8.tag + this.name.Substring(3, this.name.Length - 3);
                    foreach (Transform t in r8.transform)
                    {
                        t.gameObject.name = r8.name;
                    }
              
                //Debug.Log(cycle);
                //set ther cycle to false to ensure that the script only runs once
                cycle = false;
                if (spawner.GetComponent<Parameters>().cc_mode && this.name.Substring(3, this.name.Length - 3) == "1")
                {
                    //move cc point higher
                    spawner.GetComponent<Parameters>().cc.y += height / 2;
                    //disable (only run once)
                }
               
            }

        }
        
    }

    // checks if all the Objects (cells) in the array are grown to their respective max growth radius
    bool AreGrown(GameObject[] os)
    {
        foreach (GameObject o in os)
        {

            if (o.transform.localScale.x <= o.GetComponent<Growth>().maxRadius) { return false; }

        }


        return true;
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

}
