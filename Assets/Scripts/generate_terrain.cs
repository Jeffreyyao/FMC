using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_terrain : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;
    public GameObject cobblestone;

    System.Random r = new System.Random();

    float size = 30;

    void Start()
    {
        int[,] grass_top = generate_top();
        int min_grass_top = grass_top[0, 0];
        for(int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (grass_top[i, j] < min_grass_top)
                {
                    min_grass_top = grass_top[i, j];
                }
            }
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(grass, new Vector3(i, grass_top[i, j], j),new Quaternion(0,0,0,0));
                //for(int k = min_grass_top; k < grass_top[i, j]; k++)
                //{
                //    Instantiate(dirt, new Vector3(i, k, j), new Quaternion(0, 0, 0, 0));
                //}
                //Instantiate(cobblestone, new Vector3(i, min_grass_top-1, j), new Quaternion(0, 0, 0, 0));
            }
        }

    }

    int[,] generate_top()
    {
        int offsetX = r.Next(0, 999);
        int offsetY = r.Next(0, 999);
        float scale = 15;
        int[,] top = new int[(int)size, (int)size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                top[i,j] = (int)(scale * Mathf.PerlinNoise((offsetX + i / size), (offsetY + j / size)) - scale / 2);
            }
        }
        return top;
    }
}
