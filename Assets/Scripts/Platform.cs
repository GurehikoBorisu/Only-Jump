using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float sphereRadius;
    public float delay;
    bool playerDetected = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 1.5f, 0), sphereRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position + new Vector3(0, 1.5f, 0), sphereRadius) && !playerDetected)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    collider.gameObject.transform.parent = transform;
                    playerDetected = true;
                }
            }
        }
        else if (!Physics.CheckSphere(transform.position + new Vector3(0, 1.5f, 0), sphereRadius) && playerDetected)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    collider.gameObject.transform.parent = null;
                    playerDetected = false;
                }
            }
        }
    }
}
