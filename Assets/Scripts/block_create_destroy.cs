using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block_create_destroy : MonoBehaviour
{
    public Camera camera;

    public Text text;

    public GameObject cobblestone;
    public GameObject grass;
    public GameObject dirt;

    List<GameObject> cubeList;
    int cubeListIndex = 0;

    void Start()
    {
        cubeList = new List<GameObject>()
        {
            cobblestone,
            grass,
            dirt
        };
    }

    void Update()
    {
        //Switch cubeListIndex
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cubeListIndex++;
            if (cubeListIndex == cubeList.Count)
            {
                cubeListIndex = 0;
            }
            text.text = cubeList[cubeListIndex].name;
        }

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        //Destroy Cubes
        if (Input.GetKeyDown(KeyCode.Mouse0)||Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag != "Cube")
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
            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 hitPos = hit.point;
                Vector3 hitTransPos;
                if (hit.transform.tag == "Cube")
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
