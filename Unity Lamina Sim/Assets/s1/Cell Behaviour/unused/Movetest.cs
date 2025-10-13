using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.GetChild(28).GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,-0.01f));
        foreach (Transform t in this.transform)
        {
            t.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -0.001f));
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
