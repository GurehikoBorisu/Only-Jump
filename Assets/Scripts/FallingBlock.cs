using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float sphereRadius;
    Rigidbody rb;
    public float delay;
    bool playerDetected = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 2, 0), sphereRadius);
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position + new Vector3(0,2,0), sphereRadius) && !playerDetected)
        {
            StartCoroutine("Fall");
            playerDetected = true;
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
    }
}