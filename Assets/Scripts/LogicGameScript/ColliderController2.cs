using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController2 : MonoBehaviour
{
    bool isNextDoor;
    bool isNextBlock;
    public GameObject nextBlock;
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        isNextDoor = nextBlock.GetComponent<ColliderController>().isNextDoor;
        if (isNextDoor && isNextBlock)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            isNextBlock = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            isNextBlock = false;
        }
    }
}
