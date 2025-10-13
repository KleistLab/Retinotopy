using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrownBone : MonoBehaviour
{
    //Script X
    public Behaviour script;
    //deviation from current max Growth size
    public float x = 0;
    // cell 
    private GameObject g;
    // desired size, when the behaviour should start
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        //get parent (the cell the bone part) and its max Radius, determined by Growth Component'adjust with x if needed
       
        g = transform.parent.gameObject;
        size = g.GetComponent<Growth>().maxRadius-x;
        script.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //if the parent(cell) has reached desired size enable the behaviour (drag the component in Object Viewer)
        if (g.transform.localScale[0] >= size )
        {
            script.enabled = true;
            this.enabled = false;
            
        }
    }
}
