using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject[] door;
    public int count;

    public bool isButtons_1;

    void Update()
    {
        if (count == 2)
        {
           
            Destroy(door[0]);
        }

        if (count == 1)
        {
            Destroy(door[1]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            count = 2;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            count = 1;
        }
    }
}
