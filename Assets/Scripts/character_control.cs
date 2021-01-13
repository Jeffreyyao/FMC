using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_control : MonoBehaviour
{
    float yaw = 0f;
    float speed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        yaw += 5f * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0f, yaw, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward*speed + new Vector3(0,rb.velocity.y,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward*speed + new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right*speed + new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right*speed + new Vector3(0, rb.velocity.y, 0);
        }
        if(Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.A)||
            Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetComponent<Rigidbody>().AddForce(0, 9999999+20000000, 0);
        }
    }
}
