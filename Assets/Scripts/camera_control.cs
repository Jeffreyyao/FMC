using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
	float speed = 7f;
    float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        pitch -= speed * Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }
}
