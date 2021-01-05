using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_terrain : MonoBehaviour
{
    public GameObject grass;
    public GameObject character;

    System.Random r = new System.Random();

    int offsetX, offsetY;

    float size = 30;

    Vector3 lastCharPos;

    List<GameObject> cubes = new List<GameObject>();

    List<Vector2> map = new List<Vector2>();

    List<Vector2> addedCubes = new List<Vector2>();

    float lastRefreshTime = 0f;

    void Start()
    {
        //Randomize position offset for randomized perlin noise
        offsetX = r.Next(0, 999);
        offsetY = r.Next(0, 999);

        //Create top grass cubes
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                cubes.Add(Instantiate(grass,
                    new Vector3(i, generate_top(i,j), j), Quaternion.identity));
                map.Add(new Vector2(i, j));
            }
        }
        character.transform.position = new Vector3(size / 2, 4, size / 2);
    }

    void Update()
    {
        if (Time.time - lastRefreshTime > .5f)
        {
            for (int i = (int)character.transform.position.x - (int)size / 2;
                i < (int)character.transform.position.x + (int)size / 2; i++)
            {
                for (int j = (int)character.transform.position.z - (int)size / 2;
                    j < (int)character.transform.position.z + (int)size / 2; j++)
                {
                    if (!map.Contains(new Vector2(i, j)))
                    {
                        Instantiate(grass, new Vector3(i, generate_top(i, j), j), Quaternion.identity);
                        map.Add(new Vector2(i, j));
                    }
                }
            }
            lastRefreshTime = Time.time;
        }
    }

    int generate_top(int x, int z)
    {
        float scale = 20f;
        int res = (int)(scale * Mathf.PerlinNoise(
            offsetX + x / size, offsetY + z / size) - scale / 2);
        return res;
    }
}
