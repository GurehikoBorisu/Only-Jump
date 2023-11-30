using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement player;
    private LevelCompletePanel levelCompletePanel;
    public bool isDestroyWall = false;
    public bool isDead;

    public int health = 100;

    private void Awake()
    {
        levelCompletePanel = FindAnyObjectByType<LevelCompletePanel>();
    }
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        isDead = true;
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
        if (hit.collider.CompareTag("Finish1"))
        {
            //levelCompletePanel.islevelComletePanel = true;
        }
    }


}
