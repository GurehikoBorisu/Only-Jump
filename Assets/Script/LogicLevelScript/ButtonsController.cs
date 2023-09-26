using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public GameObject[] doors;
    private bool isButt;

    void Start()
    {
        
    }

    void Update()
    {
        if (isButt)
        {
            Destroy(doors[0]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "4")
        {
            isButt = true;
        }
    }
}
