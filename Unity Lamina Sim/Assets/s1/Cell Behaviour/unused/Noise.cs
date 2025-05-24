using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Noise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //check if flamingo on

        //if on --> noise reduction/negation
        //if off --> spawpos + spawnttime verzogerung
        //add spawn timer (internal variable of each cell)
        //add direction noise to spawn


        //SECONF
        // Random random = new Random();
        //sdk mutant - [1,6,3,4]
        //for (i=0,i < sca,i++) //sca num of max sca 
        //{
        // R=mutants[random.next(0, mutants.length)]
        // r= random.next(0, rows)
        //b= random.next(0, bundle)
        //p=random.next(0, 27)
        // if (in list)
        //  i-1
        //
        // if else (not int the list)
        //  put into list 
        // --> also sdk is turned off in this cell
        //foreach (Transform child in this.transform)
        //{
        // Sidekick sdk = child.GetComponent<FlamingoR2R5>();
        // sdk.enabled = false;
        //}


        //THIRD
        //flamingo mutant - [2,5]
        //for (i=0,i < sca,i++) //sca num of max sca 
        //{
        // pick random R
        // pick random row+bundle 
        // pick random 0-27
        // --> also fmi is turned off in this cell
        //
        // if (in list)
        //  i-1
        //
        // if else (not int the list)
        //  put into list 
        //}

        //FIRST
        //equator
        // bundel num/2 high chance of turning 
        //example 10 bund 5th 70% 6th 85% 7th 100% rest 
        //70+(15*(i-midnum)
        // calculate turning bundle fpr each row beforehand --> apply then
        // if cell is turned --> mirror 1-3 4-6
        // R3- 9 ->19
        // R4- 4 ->25
        // R1- 20 ->8
        // R6- 20 ->8
    }


    // Update is called once per framese
    void Update()
    {
        
    }
}
 