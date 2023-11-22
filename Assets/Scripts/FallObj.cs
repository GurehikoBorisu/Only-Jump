using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObj : MonoBehaviour
{
    public float Distance = 2f;
    public LayerMask LayerMask;

    public Rigidbody Rigidbody;

    public Vector3 vector;
    void Update()
    {
        CheckingPlayer();
    }


    void CheckingPlayer()
    {
        Ray ray = new Ray(transform.position, vector);
        Debug.DrawRay(ray.origin, ray.direction * Distance);

        if (Physics.Raycast(ray, Distance, LayerMask))
        {
            Rigidbody.isKinematic = false;
        }
    }
}
