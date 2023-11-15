using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float sphereRadius;
    Rigidbody rb;
    public float delay;
    bool playerDetected = false;
    public LayerMask layer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, sphereRadius, layer) && !playerDetected)
        {
            StartCoroutine("Fall");
            playerDetected = true;
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
        yield return new WaitForSeconds(delay/2);
        rb.GetComponent<Collider>().isTrigger = true;
    }
}