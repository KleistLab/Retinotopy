using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullyGrown : MonoBehaviour
{
    //Script X
    public Behaviour script;

    // desired size, when the behaviour should start
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        //get the grown radius
        size = GetComponent<Growth>().maxRadius;
        script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the cell has reached desired size enable the behaviour (drag the component in Object Viewer)
        if (transform.localScale[0] >= size ) {
            script.enabled = true;
            this.enabled= false;
            
        }
       // do script X
    }
}
