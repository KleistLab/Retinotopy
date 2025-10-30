using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Parameters : MonoBehaviour
{ 
    //general param f.e. amount of cells in one row  -> i.e. determines the number of bundels 
    public int rows = 3;
    public int amount = 5;
    [HideInInspector] public bool zigzag = false;

    //spawn param
    public int[] spawnplace_34 = { 9,5 };
    public int[] spawnplace_16 = { 20, 20 };

    //olor fmi decay/actv param
    public string decay_time = "111";
    public int fmi_time = 1;
    public bool Equator = false;
    
    //olor joints and forces
    
    [HideInInspector] public float[] joint_param = { 1, 0, 0 };
    [HideInInspector] public float strength_shy = 0;
    [HideInInspector] public float strength_loyal = 0;

    //zz mode
    [HideInInspector] public bool mode = true;
    [HideInInspector] public float zz_factor = 1.9f;
    [HideInInspector] public float zz_space = 1.5f;

    //cluster mode
    [HideInInspector] public bool cc_mode;
    [HideInInspector] public Vector3 cc;
    [HideInInspector] public float cc_height,cc8,cc2, cc5;

    [HideInInspector] public float mov_str =1;

   
    

    //mutation variables
    [HideInInspector] public int num_sdk;
    [HideInInspector] public string[] sdk_mut;
    [HideInInspector] public int num_fmi=3;
    [HideInInspector] public string[] fmi_mut;
    [HideInInspector] public string[][] rot_mut;
    [HideInInspector] public string[] fmi_rot_mut;
    public bool fmi = false;
    public bool fmi_sparse = false;
    public bool sdk = false;
    public bool GLUE = false;
    

    private int b, r;

    private string[] heels_fmi = {  "R2", "R5"};
    private string rot;
    // Start is called before the first frame update
    void Start()
    {

        // rot. mutant (one bundle for now)
        //SDK
        //leave himn like this 
        rot_mut = new string[][] { new[] { "1", "2" } };

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
        //}
        if (fmi_sparse)
        {
            fmi_mut = new string[num_fmi];
            for (int i = 0; i < num_fmi; i++)
            {
                b = UnityEngine.Random.Range(0, amount);
                r = UnityEngine.Random.Range(0, rows);
                int h = UnityEngine.Random.Range(0, 2);
                string heel = heels_fmi[h];
                fmi_mut[i] = r + heel + b;
               // Debug.Log(fmi_mut[i]);
            }
        }
        if (fmi) {
            UnityEngine.Random.InitState(42);
            int bund_num = amount*rows;
            fmi_rot_mut = new string[bund_num];
            for (int i = 0; i < bund_num; i++)
            {
                
                rot = UnityEngine.Random.Range(0, 6).ToString();

                fmi_rot_mut[i] = rot;
                 //Debug.Log(rot);
            }
           
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAm(int i)
    {
        amount = i;
    }
    public void SetRows(int i)
    {
        rows = i;
    }
    public void SetMov(float i)
    {
        mov_str = i;
    }
    public void Set34(int[] i)
    {
        spawnplace_34 = i;
    }
    public void Set16(int[] i)
    {
        spawnplace_16 = i;
    }

    public void SetDecay(string i)
    {
        decay_time = i;
    }

    public void SetShy(float i)
    {
        strength_shy = i;
    }
    public void SetLoyal(float i)
    {
        strength_loyal = i;
    }

    public void SetFmi(int i)
    {
        fmi_time = i;
    }

    public void SetJoint(float[] i)
    {
       joint_param = i;
    }

    public void SetZfac(float i) {
    
        zz_factor = i;
    }

    public void SetZspace(float i)
    {
    zz_space = i;
    }
    public void Setcc(bool i)
    {
        if (i) 
        { 
        cc_mode = true;
            mode = false;
        }
        else { 
            
            cc_mode = false;
            mode = true;
        }
    }
    public void Setccheight(float i)
    {
        cc_height = i;
    }

    public void Setcc8(float i)
    {
        cc8 = i;
    }

    public void Setcc2(float i)
    {
        cc2 = i;
    }
    public void Setcc5(float i)
    {
        cc5 = i;
    }
    public void SetEq(bool i)
    {
        Equator = i;
    }

    public void SetRTL(bool i)
    {
        mode = i;
    }

    public void SetMutFmi(bool i)
    {
        fmi = i;
        //if (fmi)
        //{
        //    UnityEngine.Random.InitState(42);
        //    int bund_num = amount * rows;
        //    fmi_rot_mut = new string[bund_num];
        //    for (int j = 0; j < bund_num; j++)
        //    {

        //        rot = UnityEngine.Random.Range(0, 6).ToString();

        //        fmi_rot_mut[j] = rot;
        //        Debug.Log(rot);
        //    }

        //}
    }
    public void SetMutSdk(bool i)
    {
        sdk = i;
    }

    public void SetGlue(bool i)
    {
        GLUE = i;
    }
}
