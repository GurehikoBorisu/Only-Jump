using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform player;
    public Vector3 range;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(range.x, range.y, range.z);
    }
}
