using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed = 20;
    public Vector3 rotate;
    void Update()
    {
        transform.Rotate(rotate * speed * Time.deltaTime);
    }
}
