using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_control : MonoBehaviour
{
    float yaw = 0f;
    float translate_speed = 0.2f;

    void Update()
    {
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
            transform.Translate(new Vector3(0, translate_speed, 0), transform);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(0, -translate_speed, 0), transform);
        }
    }
}
