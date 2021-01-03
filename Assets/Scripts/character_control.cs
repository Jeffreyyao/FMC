using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_control : MonoBehaviour
{
    float yaw = 0f;
    float translate_speed = 0.2f;

    bool isFly = true;
    float lastClickTime = 0f;
    float catchTime = 0.25f;

    void Update()
    {
        //Detect double click
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastClickTime < catchTime)
            {
                isFly = !isFly;
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.GetComponent<Rigidbody>().isKinematic = isFly;
                transform.GetComponent<Rigidbody>().useGravity = !isFly;
            }
            lastClickTime = Time.time;
        }

        yaw += 5f * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0f, yaw, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, translate_speed), transform);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -translate_speed), transform);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-translate_speed, 0, 0), transform);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(translate_speed, 0, 0), transform);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isFly)
            {
                transform.Translate(new Vector3(0, translate_speed, 0), transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isFly)
            {
                transform.GetComponent<Rigidbody>().AddForce(0, 9999999+20000000, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(0, -translate_speed, 0), transform);
        }
    }
}
