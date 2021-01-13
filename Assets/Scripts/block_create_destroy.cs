using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block_create_destroy : MonoBehaviour
{
    public Camera cam;

    public RawImage cubeIndicator;

    public GameObject cobblestone;
    public GameObject grass;
    public GameObject dirt;
    public GameObject glowstone;
    public GameObject brick;
    public GameObject glass;
    public GameObject quartz;

    public Texture cobblestone_t;
    public Texture grass_t;
    public Texture dirt_t;
    public Texture glowstone_t;
    public Texture brick_t;
    public Texture glass_t;
    public Texture quartz_t;

    List<GameObject> cubeList;
    List<Texture> textureList;
    int cubeListIndex = 0;

    void Start()
    {
        cubeList = new List<GameObject>()
        {
            cobblestone,
            grass,
            dirt,
            glowstone,
            brick,
            glass,
            quartz
        };
        textureList = new List<Texture>()
        {
            cobblestone_t,
            grass_t,
            dirt_t,
            glowstone_t,
            brick_t,
            glass_t,
            quartz_t
        };

        string saved_blocks = PlayerPrefs.GetString("saved_blocks", "");
        Debug.Log(saved_blocks);
        if (saved_blocks != "")
        {
            string[] cubes = saved_blocks.Split(new char[] { '\n' });
            List<string> cubeData = new List<string>(cubes);
            cubeData.RemoveAt(cubeData.Count - 1);
            foreach (string s in cubeData)
            {
                string name = s.Split(new char[] { ';' })[0];
                string pos = s.Split(new char[] { ';' })[1];
                Vector3 p = new Vector3(
                    float.Parse(pos.Split(new char[] { ',' })[0]),
                    float.Parse(pos.Split(new char[] { ',' })[1]),
                    float.Parse(pos.Split(new char[] { ',' })[2])
                );
                foreach(GameObject g in cubeList)
                {
                    if (name == g.name)
                    {
                        Instantiate(g, p, Quaternion.identity);
                    }
                }
            }
        }
    }

    void Update()
    {
        cubeIndicator.rectTransform.anchoredPosition = new Vector3(-Screen.width/2, Screen.height/2-80, 0);

        //Switch cubeListIndex
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cubeListIndex++;
            if (cubeListIndex == cubeList.Count)
            {
                cubeListIndex = 0;
            }
            cubeIndicator.texture = textureList[cubeListIndex];
        }

        RaycastHit hit;

        //Destroy Cube
        if (Input.GetKeyDown(KeyCode.Mouse0)||Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit, 15))
            {
                if (hit.transform.tag != "Cube" && hit.transform.tag != "Terrain")
                {
                    Destroy(hit.transform.parent.gameObject);
                }
                else
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }

        //Create Cube
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.R))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit, 15))
            {
                Vector3 hitPos = hit.point;
                Vector3 hitTransPos;
                if (hit.transform.tag == "Cube" || hit.transform.tag == "Terrain")
                {
                    hitTransPos = hit.transform.position;
                }
                else
                {
                    hitTransPos = hit.transform.parent.position;
                }
                if ((hitPos.y - hitTransPos.y) > 0.499 && (hitPos.y - hitTransPos.y) < 0.501)
                {
                    Instantiate(cubeList[cubeListIndex],
                        new Vector3(hitTransPos.x,hitTransPos.y+1,hitTransPos.z),
                        new Quaternion(0, 0, 0, 0));
                }
                else if ((hitPos.y - hitTransPos.y) < -0.499 && (hitPos.y - hitTransPos.y) > -0.501)
                {
                    Instantiate(cubeList[cubeListIndex],
                        new Vector3(hitTransPos.x, hitTransPos.y - 1, hitTransPos.z),
                        new Quaternion(0, 0, 0, 0));
                }
                else if ((hitPos.x - hitTransPos.x) > 0.499 && (hitPos.x - hitTransPos.x) < 0.501)
                {
                    Instantiate(cubeList[cubeListIndex],
                        new Vector3(hitTransPos.x+1, hitTransPos.y, hitTransPos.z),
                        new Quaternion(0, 0, 0, 0));
                }
                else if ((hitPos.x - hitTransPos.x) < -0.499 && (hitPos.x - hitTransPos.x) > -0.501)
                {
                    Instantiate(cubeList[cubeListIndex],
                        new Vector3(hitTransPos.x - 1, hitTransPos.y, hitTransPos.z),
                        new Quaternion(0, 0, 0, 0));
                }
                else if ((hitPos.z - hitTransPos.z) > 0.499 && (hitPos.z - hitTransPos.z) < 0.501)
                {
                    Instantiate(cubeList[cubeListIndex],
                        new Vector3(hitTransPos.x, hitTransPos.y, hitTransPos.z+1),
                        new Quaternion(0, 0, 0, 0));
                }
                else if ((hitPos.z - hitTransPos.z) < -0.499 && (hitPos.z - hitTransPos.z) > -0.501)
                {
                    Instantiate(cubeList[cubeListIndex],
                        new Vector3(hitTransPos.x, hitTransPos.y, hitTransPos.z-1),
                        new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
