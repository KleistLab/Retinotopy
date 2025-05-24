using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using NUnit.Framework;

using UnityEngine.TestTools;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Linq.Expressions;

using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Schema;

public class test
{
    // A Test behaves as an ordinary method
    [Test]
    public void testSimplePasses()
    {

        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    //static int[] column_num = new int[] { 3, 5, 7 };   


    //static int[][][] spawnplace1 = new int[][][] { new int[][]{ new[] { 6, 4 }, new[] { 20, 20 } }, new int[][] { new[] { 6, 4 }, new[] { 19, 20 } }, new int[][] { new[] { 6, 4 }, new[] { 20, 19 } }, new int[][] { new[] { 6, 4 }, new[] { 21, 20 } }, new int[][] { new[] { 6, 4 }, new[] { 20, 21 } }, new int[][] { new[] { 6, 4 }, new[] { 21, 21 } }, new int[][] { new[] { 6, 4 }, new[] { 21, 19 } }, new int[][] { new[] { 6, 4 }, new[] { 19, 21 } },
      //                                              new int[][]{ new[] { 7, 4 }, new[] { 20, 20 } }, new int[][] { new[] { 7, 4 }, new[] { 19, 20 } }, new int[][] { new[] { 7, 4 }, new[] { 20, 19 } }, new int[][] { new[] { 7, 4 }, new[] { 21, 20 } }, new int[][] { new[] { 7, 4 }, new[] { 20, 21 } }, new int[][] { new[] { 7, 4 }, new[] { 21, 21 } }, new int[][] { new[] { 7, 4 }, new[] { 21, 19 } }, new int[][] { new[] { 7, 4 }, new[] { 19, 21 } },
      //                                              new int[][]{ new[] { 8, 4 }, new[] { 20, 20 } }, new int[][] { new[] { 8, 4 }, new[] { 19, 20 } }, new int[][] { new[] { 8, 4 }, new[] { 20, 19 } }, new int[][] { new[] { 8, 4 }, new[] { 21, 20 } }, new int[][] { new[] { 8, 4 }, new[] { 20, 21 } }, new int[][] { new[] { 8, 4 }, new[] { 21, 21 } }, new int[][] { new[] { 8, 4 }, new[] { 21, 19 } }, new int[][] { new[] { 8, 4 }, new[] { 19, 21 } }};
    //static int[][] spawnplace = new int[][] { new[] { 9, 5 }};

    //static int[][] spawnplace2 = new int[][] { new[] { 18, 23 }, new[] { 18, 24 }, new[] { 18, 22 }, new[] { 18, 21 }, new[] { 18, 20 }, new[] { 21, 21 }, new[] { 20, 21 }, new[] { 19, 22 }, new[] { 19, 21 }, new[] { 19, 20 } };
    // static int[][] spawnplace = new int[][] { new[] { 19, 23 } };

    // 
    //static float[][] str = new float[][] { new[] { 1f, 2f }, new[] { 2f, 1f }, new[] { 2f, 2f }, new[] { 2f, 3f }, new[] { 3f, 2f }, new[] { 3f, 3f } };


    //static string[] result = new string[] {
    //    "0000","0001", "0002","0010","0011", "0012","0020", "0021","0022", "0100","0101","0102","0110", "0111","0112", "0120","0121", "0122", "0200", "0201","0202", "0210","0211", "0212","0220", "0221","0222",
    //    "1000","1001","1002","1010", "1011", "1012","1020", "1021","1022", "1100","1101","1102", "1110","1111", "1112","1120", "1121", "1122","1200","1201", "1202","1210", "1211", "1212", "1220", "1221","1222",
    //    "2000","2001","2002","2010","2011","2012","2020","2021","2022","2100","2101","2102","2110","2111","2112","2120","2121","2122","2200","2201","2202","2210","2211","2212","2220","2221","2222" };

    // static string[] result = new string[] { "1221" };
    //static int[][] result = new int[][] { new[] { 1,1,1,1 }, new[] { 2,2,2,2 }, new[] { 3,3,3,3 } };

    //static string[] result = new string[] { "3000", "3001", "3002", "3010", "3011", "3012", "3020", "3021", "3022", "3100", "3101", "3102", "3110", "3111", "3112", "3120", "3121", "3122", "3200", "3201", "3202", "3210", "3211", "3212", "3220", "3221", "3222",
    //                                         "3003", "3013","3023","3030","3031","3032","3033","3103","3113","3123","3130","3131","3132","3133","3203","3213","3223","3230","3231","3232","3233","3300","3301","3302","3303","3310","3311","3312","3313","3320","3321","3322","3323","3330","3331","3332","3333",
    //                                         "0003", "0013","0023","0030","0031","0032","0033","0103","0113","0123","0130","0131","0132","0133","0203","0213","0223","0230","0231","0232","0233","0300","0301","0302","0303","0310","0311","0312","0313","0320","0321","0322","0323","0330","0331","0332","0333",
    //                                         "1003", "1013","1023","1030","1031","1032","1033","1103","1113","1123","1130","1131","1132","1133","1203","1213","1223","1230","1231","1232","1233","1300","1301","1302","1303","1310","1311","1312","1313","1320","1321","1322","1323","1330","1331","1332","1333",
    //                                         "2003", "2013","2023","2030","2031","2032","2033","2103","2113","2123","2130","2131","2132","2133","2203","2213","2223","2230","2231","2232","2233","2300","2301","2302","2303","2310","2311","2312","2313","2320","2321","2322","2323","2330","2331","2332","2333"};

    //static string[] result = new string[] { //"000", "001", "002", "003", "010", "011", "012", "013", "020", "021", "022", "023", "030", "031", "032", "033",
    //"100", "101", "102", "103", "110", "111", "112", "113", 
    //    "120",// "121", "122", "123", "130", "131", 
    //    "132", "133",
    //"200", "201", "202", "203", "210", "211", "212", "213", "220", "221", "222", "223"//, "230", "231", "232", "233",
    //"300", "301", "302", "303", "310", "311", "312", "313", "320", "321", "322", "323", "330", "331", "332", "333"
   // };
    //static float[][] str = new float[][] { new[] { 1f, 0f, 0f },new[] { 1f, 0.1f, 0f }, new[] { 1f, 0.3f, 0f }, new[] { 1f, 0.6f, 0f }, new[] { 1f, 1f, 0f }, new[] { 1f, 0f, 1f }, new[] { 1f, 0f, 3f }, new[] { 1f, 0f, 6f },  new[] { 1f, 0f, 15f },
    //                                      new[] { 10f, 0.1f, 0f }, new[] { 10f, 0.3f, 0f }, new[] { 10f, 0.6f, 0f }, new[] { 10f, 1f, 0f }, new[] { 10f, 0f, 1f }, new[] { 10f, 0f, 3f }, new[] { 10f, 0f, 6f }, new[] { 10f, 0f, 15f }};

    //static float[] strfunky = new float[] { 0, 0.5f, 1, 2, 3, 4, 5, 10, 50, 100, 500 };
    //static float[][] strfunky = new float[][] { new[] { 0f, 0f }, new[] { 0.5f, 0.5f },new[] { 1f, 1f }, new[] { 5f, 5f }, new[] { 10f, 10f },
    //                                            new[] { 1f, 0f }, new[] { 1f, 0.5f },new[] { 0f, 1f }, new[] { 0.5f, 1f }, new[] { 5f, 1f }, new[] { 1f, 5f }};

    //static float[] zz_f = new float[] { 0,0.5f,1,1.5f,1.7f,1.9f,2.1f,2.3f };
    //static float[] zz_s = new float[] { 0, 0.5f, 1, 1.5f, 1.7f, 1.9f, 2.1f, 2.3f,2.5f,2.7f };
    //static float[] cch = new float[] {2,4,6,8,10,12,16,18,20,22,24};
    //static float[] cc8 = new float[] { 0, 0.5f, 1, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2, 2.1f, 2.2f, 2.3f, 2.4f, 2.5f };
    //static float[] cc2 = new float[] { 0,0.025f, 0.05f,0.075f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, };
    //static float[] cc5 = new float[] { 0,0.025f, 0.05f,0.075f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, };

    static int[] trck = new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                                 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55,56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89,90, 91, 92, 93, 94, 95, 96, 97, 98, 99};
    //UNTILL 60
    //0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
    //                                31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55,56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89,90, 91, 92, 93, 94, 95, 96, 97, 98, 99
    // static int[] time = new int[] { 0,1,2,3};
    [UnityTest]
    //public IEnumerator spawnplace_turned([ValueSource("spawnplace1")] int[][] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera big"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));

    //    spawner.GetComponent<Parameters>().Set34(value[0]);
    //    spawner.GetComponent<Parameters>().Set16(value[1]);
    //    spawner.GetComponent<Parameters>().SetDecay("111");
    //    spawner.GetComponent<Parameters>().Setcc(false);
    //    //spawner.GetComponent<Parameters>().SetRTL(false);
    //    spawner.GetComponent<Parameters>().SetAm(8);
    //    spawner.GetComponent<Parameters>().SetRows(4);
    //    spawner.GetComponent<Parameters>().SetEq(false);
    //    spawner.GetComponent<Parameters>().SetFmi(1);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(Application.dataPath + value[0][0] + "_" + value[1][0] + "_" + value[1][1
    //         ] + "_spawnplace.png");
    //    //string path = Application.persistentDataPath + "/second_111_1_norm_test_rtl_" + value + ".txt";
    //    ////Write some text to the test.txt file
    //    //StreamWriter writer = new StreamWriter(path, false);

    //    //GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
    //    //foreach (GameObject o in objects)
    //    //{
    //    //    if (o.name[1] == 'R')
    //    //    {
    //    //        //Debug.Log(o.name);
    //    //        writer.WriteLine(o.name + " " + o.tag + " " + o.transform.GetChild(28).transform.position);
    //    //        //+ o.transform.GetChild(28).transform.position
    //    //    }

    //    //}
    //    //writer.Close();
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    public IEnumerator tracking_data_eq([ValueSource("trck")] int value)
    {
        ////TEST EQ
        //Time.timeScale = 2f;
        //GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        //GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
        ////GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
        //spawner.GetComponent<Parameters>().Set16(new int[] { 20, 20 });
        //spawner.GetComponent<Parameters>().Set34(new int[] { 9, 4 });
        //spawner.GetComponent<Parameters>().SetDecay("111");
        //spawner.GetComponent<Parameters>().Setcc(false);
        ////spawner.GetComponent<Parameters>().SetRTL(false);
        //spawner.GetComponent<Parameters>().SetAm(6);
        //spawner.GetComponent<Parameters>().SetRows(4);
        //spawner.GetComponent<Parameters>().SetEq(true);
        //spawner.GetComponent<Parameters>().SetFmi(1);
        ////yield return new WaitForSeconds(80); //3rows
        //yield return new WaitForSeconds(120);    //4rows
        ////yield return new WaitForSeconds(160); //5

        //string path = Application.persistentDataPath + "/111_1_eq_test_rtl_" + value + ".txt";
        ////Write some text to the test.txt file
        //StreamWriter writer = new StreamWriter(path, false);

        //GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
        //foreach (GameObject o in objects)
        //{
        //    if (o.name[1] == 'R')
        //    {
        //        //Debug.Log(o.name);
        //        writer.WriteLine(o.name + " " + o.tag + " " + o.transform.GetChild(28).transform.position);
        //        //+ o.transform.GetChild(28).transform.position
        //    }

        //}
        //writer.Close();
        ////StreamReader reader = new StreamReader(path);
        ////Print the text from the file
        ////Debug.Log(reader.ReadToEnd());
        ////reader.Close();
        //objects = GameObject.FindObjectsOfType<GameObject>();
        //foreach (GameObject o in objects)
        //{
        //    GameObject.Destroy(o);
        //}

        //TEST WO EQ
        Time.timeScale = 2f;
        GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
        //GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
        spawner.GetComponent<Parameters>().Setcc(false);
        //spawner.GetComponent<Parameters>().SetRTL(false);
        spawner.GetComponent<Parameters>().SetAm(8);
        spawner.GetComponent<Parameters>().SetRows(4);
        spawner.GetComponent<Parameters>().SetEq(false);
        spawner.GetComponent<Parameters>().SetFmi(1);
        spawner.GetComponent<Parameters>().Set16(new int[] { 20, 20 });
        spawner.GetComponent<Parameters>().Set34(new int[] { 9, 3 });
        spawner.GetComponent<Parameters>().SetDecay("111");

        //yield return new WaitForSeconds(80); //3rows
        yield return new WaitForSeconds(120);    //4rows
                                                 //yield return new WaitForSeconds(160); //5

        string path = Application.persistentDataPath + "/fmi_half_turned_test_" + value + ".txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);

        GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
        foreach (GameObject o in objects)
        {
            if (o.name[1] == 'R')
            {
                //Debug.Log(o.name);
                writer.WriteLine(o.name + " " + o.tag + " " + o.transform.GetChild(28).transform.position);
                //+ o.transform.GetChild(28).transform.position
            }

        }
        writer.Close();
        //StreamReader reader = new StreamReader(path);
        //Print the text from the file
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();
        objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject o in objects)
        {
            GameObject.Destroy(o);
        }

    }

    //public IEnumerator Decaytime([ValueSource("result")] string value)
    //{
    //    for (int i = 0; i < 20; i++){ 
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    //GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
    //    spawner.GetComponent<Parameters>().Set16(new int[] { 20, 20 });
    //    spawner.GetComponent<Parameters>().Set34(new int[] { 9, 4 });
    //    spawner.GetComponent<Parameters>().SetDecay(value);
    //    spawner.GetComponent<Parameters>().Setcc(false);
    //    spawner.GetComponent<Parameters>().SetAm(6);
    //    spawner.GetComponent<Parameters>().SetRows(4);
    //    spawner.GetComponent<Parameters>().SetEq(false);
    //    //yield return new WaitForSeconds(80); //3rows
    //    yield return new WaitForSeconds(120);    //4rows
    //                                             //yield return new WaitForSeconds(160); //5

    //    string path = Application.persistentDataPath + "/"+i+"new_test_rtl_" + value + ".txt";
    //    //Write some text to the test.txt file
    //    StreamWriter writer = new StreamWriter(path, false);

    //    GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
    //    foreach (GameObject o in objects)
    //    {
    //        if (o.name[1] == 'R')
    //        {
    //            //Debug.Log(o.name);
    //            writer.WriteLine(o.name + " " + o.tag + " " + o.transform.GetChild(28).transform.position);
    //            //+ o.transform.GetChild(28).transform.position
    //        }

    //    }
    //    writer.Close();
    //    //StreamReader reader = new StreamReader(path);
    //    //Print the text from the file
    //    //Debug.Log(reader.ReadToEnd());
    //    //reader.Close();
    //    objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }
    //    }
    //}
    //TODO: 
    //test 100 times, get tracking data, 80secs

    //public IEnumerator tracking_data_eq([ValueSource("trck")] int value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    //GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
    //    spawner.GetComponent<Parameters>().Set16(new int[] { 20, 20 });
    //    spawner.GetComponent<Parameters>().Set34(new int[] { 9, 4 });
    //    spawner.GetComponent<Parameters>().SetDecay("111");
    //    spawner.GetComponent<Parameters>().Setcc(false);
    //    //spawner.GetComponent<Parameters>().SetRTL(false);
    //    spawner.GetComponent<Parameters>().SetAm(6);
    //    spawner.GetComponent<Parameters>().SetRows(4);
    //    spawner.GetComponent<Parameters>().SetEq(true);
    //    spawner.GetComponent<Parameters>().SetFmi(1);
    //    //yield return new WaitForSeconds(80); //3rows
    //    yield return new WaitForSeconds(120);    //4rows
    //    //yield return new WaitForSeconds(160); //5

    //    string path = Application.persistentDataPath + "/111_1_eq_test_rtl_" + value + ".txt";
    //    //Write some text to the test.txt file
    //    StreamWriter writer = new StreamWriter(path, false);

    //    GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
    //    foreach (GameObject o in objects)
    //    {
    //        if (o.name[1] == 'R')
    //        {
    //            //Debug.Log(o.name);
    //            writer.WriteLine(o.name + " " + o.tag + " " + o.transform.GetChild(28).transform.position);
    //            //+ o.transform.GetChild(28).transform.position
    //        }

    //    }
    //    writer.Close();
    //    //StreamReader reader = new StreamReader(path);
    //    //Print the text from the file
    //    //Debug.Log(reader.ReadToEnd());
    //    //reader.Close();
    //    objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}
    //public IEnumerator tracking_data([ValueSource("trck")] int value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    //GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
    //    spawner.GetComponent<Parameters>().Set16(new int[] {20,20});
    //    spawner.GetComponent<Parameters>().Set34(new int[] { 9, 4 });
    //    spawner.GetComponent<Parameters>().SetDecay("310");
    //    spawner.GetComponent<Parameters>().Setcc(false);
    //    spawner.GetComponent<Parameters>().SetAm(6);
    //    spawner.GetComponent<Parameters>().SetRows(4);
    //    //yield return new WaitForSeconds(80); //3rows
    //    yield return new WaitForSeconds(120);    //4rows


    //    string path = Application.persistentDataPath + "/test"+value+".txt";
    //    //Write some text to the test.txt file
    //    StreamWriter writer = new StreamWriter(path, false);

    //    GameObject[] objects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(); ;
    //    foreach (GameObject o in objects)
    //    {
    //        if (o.name[1] == 'R')
    //        {
    //            //Debug.Log(o.name);
    //            writer.WriteLine(o.name + " " + o.tag + " " + o.transform.GetChild(28).transform.position);
    //            //+ o.transform.GetChild(28).transform.position
    //        }

    //    }
    //    writer.Close();
    //    //StreamReader reader = new StreamReader(path);
    //    //Print the text from the file
    //    //Debug.Log(reader.ReadToEnd());
    //    //reader.Close();
    //    objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator mov_Str([ValueSource("strfunky")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().SetMov(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "mov_str.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator bz_Spawnplace_34([ValueSource("spawnplace1")] int[] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
    //    spawner.GetComponent<Parameters>().Set34(value);
    //    spawner.GetComponent<Parameters>().Setcc(false);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_spawnplace_34.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}


    //public IEnumerator bz_Spawnplace_16([ValueSource("spawnplace2")] int[] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
    //    spawner.GetComponent<Parameters>().Set16(value);
    //    spawner.GetComponent<Parameters>().Setcc(false);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_spawnplace_16.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }
    //    yield return null;
    //}

    //public IEnumerator LateFmi([ValueSource("time")] int value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().SetFmi(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_FMI_time.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //    yield return null;
    //}

    //public IEnumerator CC_height([ValueSource("cch")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().Setcc(true);
    //    spawner.GetComponent<Parameters>().Setccheight(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_cc_height.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator CC_8([ValueSource("cc8")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().Setcc(true);
    //    spawner.GetComponent<Parameters>().Setcc8(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_cc_8.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator CC_2([ValueSource("cc2")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().Setcc(true);
    //    spawner.GetComponent<Parameters>().Setcc2(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_cc_2.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator CC_5([ValueSource("cc5")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().Setcc(true);
    //    spawner.GetComponent<Parameters>().Setcc5(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_cc_5.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}



    //public IEnumerator ZZ_f([ValueSource("zz_f")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));

    //    spawner.GetComponent<Parameters>().SetZfac(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_zz_fac.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator ZZ_s([ValueSource("zz_s")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().SetZspace(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_zz_space.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}

    //public IEnumerator Spawnplace_34([ValueSource("spawnplace1")] int[] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().Set34(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_spawnplace_34.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //}


    //public IEnumerator Spawnplace_16([ValueSource("spawnplace2")] int[] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().Set16(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_spawnplace_16.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }
    //    yield return null;
    //}

    //public IEnumerator Joints_fmi([ValueSource("str")] float[] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().SetJoint(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_" + value[2] + "_FMI_joint.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //    yield return null;
    //}

    //public IEnumerator FunkyPowers([ValueSource("strfunky")] float[] value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().SetLoyal(value[0]);
    //    spawner.GetComponent<Parameters>().SetShy(value[1]);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_str_funky.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }
    //    yield return null;
    //}






    //public IEnumerator FunkyPowers([ValueSource("strfunky")] float value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Parameters>().SetLoyal(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value + "_str_loyal.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //    // Use the Assert class to test conditions.yield return ner
    //    // Use yield to skip a frame.
    //    yield return null;
    //}



    //public IEnumerator Decaytime([ValueSource("result")] string value)
    //{
    //    Time.timeScale = 2f;
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    GameObject border = MonoBehaviour.Instantiate(Resources.Load<GameObject>("border"));
    //    spawner.GetComponent<Parameters>().SetDecay(value);
    //    yield return new WaitForSeconds(120);
    //    ScreenCapture.CaptureScreenshot(value[0] + "_" + value[1] + "_" + value[2] + "_" + value[3]+ "_decaytime.png");//
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //    yield return null;
    //}
    //public IEnumerator Column_Num([ValueSource("column_num")] int value)
    //{
    //    GameObject cam = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
    //    GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("spawner"));
    //    spawner.GetComponent<Generat8>().SetAmount(value);
    //    yield return new WaitForSeconds(10);
    //    ScreenCapture.CaptureScreenshot(value + "_column_num.png");
    //    GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
    //    foreach (GameObject o in objects)
    //    {
    //        GameObject.Destroy(o);
    //    }

    //    // Use the Assert class to test conditions.yield return ner
    //    // Use yield to skip a frame.
    //    yield return null;
    //}



    //    // Use the Assert class to test conditions.yield return ner
    //    // Use yield to skip a frame.
    //    yield return null;
    //}




}
