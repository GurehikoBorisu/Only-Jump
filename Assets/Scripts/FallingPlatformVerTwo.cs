using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformVerTwo : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("Fall");
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
        rb.AddForce(0,-50,0);
    }
}
