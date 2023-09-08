using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void EnableRagdoll()
    {
        //yield return new WaitForSecounds(1);
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }
    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }
}
