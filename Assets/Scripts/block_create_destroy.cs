using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_create_destroy : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
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
            }
        }
    }
}
