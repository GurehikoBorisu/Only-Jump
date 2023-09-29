using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject[] door;
    public int count;

    public bool isButtons_1;
    public bool isButtons_2;

    void Update()
    {                   
        if (isButtons_1)
        {          
            Destroy(door[0]);
        }

        if (isButtons_2)
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
            isButtons_2 = true;
        }       
    }
}
