using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gridline : MonoBehaviour
{
    // Start is called before the first frame update
    // code for spawner 
    //add no r8 mode
    //amount of cells in one row  -> i.e. determines the number of bundels 
    private bool zigzag;
    //amount of cells in one row  -> i.e. determines the number of bundels 
    private int amount, rows;
    //prefab, get from Object Viewer Drag Down
    public GameObject prefab2, prefab5,prefab8;
    //internal r8 object which is later intiated
    private GameObject r2, r5,r8,tocon;
    //initial spawning position
    private Vector3 position2 = new Vector3(0, 0, 0);
    private Vector3 position5 = new Vector3(0, -0.7f, 0);

    private int fin_rows = 0;
    private bool cycle = true;
    private SliderJoint2D[] joints;

    // Start is called before the first frame update
    // because it is the initial spawner script 
    // it creates a row of r8s in the beginning amd the rest
    // is spawned by later cell objects
    void Start()
    {

        amount = this.GetComponent<Parameters>().amount;
        rows = this.GetComponent<Parameters>().rows;
        zigzag = this.GetComponent<Parameters>().zigzag;
        //for the amount of wanted r8s
        // create
        // rename object + children
        // move to next spawning position
        //position constellation is according to mode
        //TODO:
        //MAKE ZIGZAG EXTREMER
        //add r8s???
            //first add r8 
            //then r2 r5
            //for loop : go through r8s and put r2r5 to each one
        for (int c = 0; c < amount; c++) //amount of wanted r8s
        {
            r8 = Instantiate(prefab8, position2, Quaternion.identity);
            

            //rename r1 object and its bones
            r8.name = this.name[0] + r8.tag + this.name.Substring(3, this.name.Length - 3);
            foreach (Transform t in r8.transform)
            {
                t.gameObject.name = r8.name;
            }
            //r2 = Instantiate(prefab2, position2, Quaternion.identity);
            //r5 = Instantiate(prefab5, position5, Quaternion.identity);
            //r2.name = 0 + r2.tag + c;
            //r5.name = 0 + r5.tag + c;
            //foreach (Transform t in r2.transform)
            //{
            //    t.gameObject.name = r2.name;
            //}
            //foreach (Transform t in r5.transform)
            //{
            //    t.gameObject.name = r5.name;
            //}
            position2.x = position2.x + 1.2f;
            //position5.x = position5.x + 1.2f;

            if (zigzag && (c % 2 == 0))
            {
                position2.y = position2.y + 0.01f + 2 * 0.9f;
                position5.y = position5.y + 0.01f + 2 * 0.9f;
            }
            else if (zigzag)
            {
                position2.y = position2.y - 0.01f - 2 * 0.9f;
                position5.y = position5.y - 0.01f - 2 * 0.9f;
            }
        }
        fin_rows++;


    }
    //void Start()
    //{
    //    //check if mode is on 
    //    //spawn ini
    //    //r8 = Instantiate(prefab, position, Quaternion.identity);
    //    //r8.name = (Char.GetNumericValue(this.name[0]) + 1) + r8.tag + this.name.Substring(3, this.name.Length - 3);
    //    //foreach (Transform t in r8.transform)
    //    //{
    //    //    t.gameObject.name = r8.name;
    //    //}
    //}

    // Update is called once per frame
    void Update()
    {
        if (cycle)
        {//spawn next
            r2 = GameObject.Find((fin_rows - 1) + "R2" + 0);


            if (r2.transform.localScale.x >= 1)
            {
                for (int c = 0; c < amount; c++) //amount of wanted r8s
                {
                    r2 = GameObject.Find((fin_rows - 1) + "R2" + c);
                    r5 = GameObject.Find((fin_rows - 1) + "R5" + c);
                    //rework ohne dopplung
                    if (c == 0)
                    {
                        tocon = GameObject.Find((fin_rows - 1) + "R2" + (c + 1)).transform.GetChild(28).gameObject;
                    }
                    else
                    {
                        tocon = GameObject.Find((fin_rows - 1) + "R2" + (c - 1)).transform.GetChild(28).gameObject;
                    }


                    position5 = r5.transform.GetChild(28).transform.position + new Vector3(0, 5, 0);
                    position2 = position5 + new Vector3(0, 0.7f, 0);
                    r2 = Instantiate(prefab2, position2, Quaternion.identity);
                    r5 = Instantiate(prefab5, position5, Quaternion.identity);
                    r2.name = fin_rows + r2.tag + c;
                    r5.name = fin_rows + r5.tag + c;
                    foreach (Transform t in r2.transform)
                    {
                        t.gameObject.name = r2.name;
                    }
                    foreach (Transform t in r5.transform)
                    {
                        t.gameObject.name = r5.name;
                    }
                    //position2.x = position2.x + 1.2f;
                    //position5.x = position5.x + 1.2f;

                    //if (zigzag && (c % 2 == 0))
                    //{
                    //    position2.y = position2.y + 0.01f + 2 * 0.9f;
                    //    position5.y = position5.y + 0.01f + 2 * 0.9f;
                    //}
                    //else if (zigzag)
                    //{
                    //    position2.y = position2.y - 0.01f - 2 * 0.9f;
                    //    position5.y = position5.y - 0.01f - 2 * 0.9f;
                    //}
                    //sliderjoint
                    joints = gameObject.GetComponents<SliderJoint2D>();
                    SliderJoint2D joint = null;

                    foreach (SliderJoint2D joint_ in joints)
                    {
                        if (tocon.gameObject.GetInstanceID() == joint_.connectedBody.gameObject.GetInstanceID())
                        {
                            joint = joint_;
                            break;
                        }
                    }
                    //Debug.Log(tocon.name);

                    ////if not bone of the same object and still joints left
                    ///do this only for r5


                    //rework with new connec

                    if (!joint)
                    {
                        joint = r5.transform.GetChild(28).gameObject.AddComponent<SliderJoint2D>();
                        // Connect Joint to colliding Object 
                        joint.connectedBody = tocon.GetComponent<Rigidbody2D>();
                        joint.enableCollision = false;
                        joint.breakForce = 0.001f;
                        joint.autoConfigureConnectedAnchor = true;
                        joint.autoConfigureAngle = true;
                        joint.angle = 0;
                        joint.useMotor = true;
                        joint.motor = new JointMotor2D { motorSpeed = 0.09f, maxMotorTorque = 100 };

                        // joint.linearOffset = new Vector2(0,0);  // for relative Joint
                        // joint.correctionScale = 0f; // for relative Joint
                    }
                    else
                    {
                        joint.enabled = true;
                    }


                }
                fin_rows++;
                //make joint -->between last childs !NOT SPRINGJOINT PLS!

                // add slider r5 prev 2s x-1 x+1 y-1
            }

        }
        if (fin_rows == rows) { cycle = false; }


    }
}

