using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_blocks : MonoBehaviour
{
    void OnApplicationQuit()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        string cubeData = "";
        foreach(GameObject g in cubes)
        {
            string name = g.name.Replace("(Clone)", "");
            string pos = g.transform.position.ToString().Replace("(","").Replace(")", "");
            
            cubeData += name + ";" + pos + "\n";
            PlayerPrefs.SetString("saved_blocks", cubeData);
        }
    }
}
