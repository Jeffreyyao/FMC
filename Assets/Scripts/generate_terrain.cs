using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_terrain : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;

    void Start()
    {
        for(int i = 1; i < 20; i++)
        {
            for(int j = 1; j < 20; j++)
            {
                Instantiate(grass, new Vector3((float)i, -1f, (float)j),
                    new Quaternion(0, 0, 0, 0));
                Instantiate(dirt, new Vector3((float)i, -2f, (float)j),
                    new Quaternion(0, 0, 0, 0));
            }
        }

    }
}
