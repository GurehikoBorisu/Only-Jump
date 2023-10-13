using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject[] door;
    public int count;

    public bool isButtons_1;

    void Update()
    {
        if (isButtons_1)
        {
            count = 0;
            Destroy(door[0]);
        }

        if (count == -1)
        {
            Destroy(door[1]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obj")
        {
            isButtons_1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obj")
        {
            count = -1;
        }
    }
}
