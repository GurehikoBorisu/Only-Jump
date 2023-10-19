using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector3 mouseVector;

    public float mouseSensitivity = 100f;

    public Transform player;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseVector.x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseVector.y= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseVector.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        player.Rotate(Vector3.up * mouseVector.x);
    }
}
