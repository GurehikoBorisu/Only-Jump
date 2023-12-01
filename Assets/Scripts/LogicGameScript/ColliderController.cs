using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject[] door;
    public int count;
    public Vector3 boxSize;
    public LayerMask layer;
    public bool isBlock;
    public bool isNextDoor;

    public bool isButtons_1;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
    void Update()
    {
        if (count == 2)
        {
           
            Destroy(door[0]);
        }
        if (Physics.CheckBox(transform.position, boxSize, new Quaternion(0, 0, 0, 0), layer) && isBlock)
        {
            Destroy(door[2]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            count = 2;
            isNextDoor = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            isNextDoor = true;
        }
    }
}
