using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    Rigidbody rb;

    public float xL;
    public float xR;   

    [SerializeField] private float speed;
    private float curentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.x > xR)
        {
            curentSpeed = -speed;
        }

        if (transform.position.x < xL)
        {
            curentSpeed = speed;
        }     
      
        rb.velocity = new Vector3(curentSpeed, rb.velocity.y, 5);
    }
}
