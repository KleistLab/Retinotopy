using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testgenerat : MonoBehaviour
{
    public int amount;
    public GameObject R8;

    public Vector3 position = new Vector3(0.2f, 0.7f, 0);
    // Start is called before the first frame update
    void Start()
    {
        for (int c = 0; c < amount; c++) //amount of wanted r8s
        {
            Instantiate(R8, position, Quaternion.identity);
            position.x = position.x + 2 * (0.06f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
