using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(track());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator track()
    {

        
        yield return new WaitForSeconds(120);
  string path = Application.persistentDataPath + "/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);

        GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
        foreach (GameObject o in objects)
        {
            if (o.name[1] == 'R') { 
                //Debug.Log(o.name);
                writer.WriteLine(o.name + " "+o.tag + " " + o.transform.GetChild(28).transform.position);
                //+ o.transform.GetChild(28).transform.position
            }
            
        }
      
       
        writer.Close();
        StreamReader reader = new StreamReader(path);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();

    }
}
