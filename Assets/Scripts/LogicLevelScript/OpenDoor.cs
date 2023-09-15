using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    private bool isOpen;
   
    void Update()
    {
        if (isOpen)
        {
            Destroy(door);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obj")
        {
            isOpen = true;
        }
    }
}
