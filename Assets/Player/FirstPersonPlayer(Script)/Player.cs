using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement player;
    public bool isDestroyWall = false;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("GravityOn"))
        {
            player.isRotating = true;
        }
        if (hit.collider.CompareTag("GravityOff"))
        {
            player.isRotating = false;
            isDestroyWall = true;
        }
    }
}
