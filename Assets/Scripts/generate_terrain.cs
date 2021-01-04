using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_terrain : MonoBehaviour
{
    public GameObject grass;

    System.Random r = new System.Random();

    float size = 50;

    void Start()
    {
        int[,] grass_top = generate_top();

        //Create top grass meshes
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(grass,
                    new Vector3(i, grass_top[i, j], j), Quaternion.identity);
            }
        }
    }

    void create_mesh(Material mat, Vector3[] vertices)
    {
        GameObject t = new GameObject();
        t.tag = "Cube";
        MeshRenderer mr = t.AddComponent<MeshRenderer>();
        mr.sharedMaterial = new Material(mat);
        MeshFilter mf = t.AddComponent<MeshFilter>();
        Mesh m = new Mesh();
        m.vertices = vertices;
        int[] tris = new int[6]
        {
            0,2,1,2,3,1
        };
        m.triangles = tris;
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        m.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        m.uv = uv;
        mf.mesh = m;
        t.AddComponent<MeshCollider>();
    }

    int[,] generate_top()
    {
        int offsetX = r.Next(0, 999);
        int offsetY = r.Next(0, 999);
        float scale = 20;
        int[,] top = new int[(int)size, (int)size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                top[i, j] = (int)(scale * Mathf.PerlinNoise(
                    offsetX + i / size, offsetY + j / size) - scale / 2);
            }
        }
        return top;
    }
}
