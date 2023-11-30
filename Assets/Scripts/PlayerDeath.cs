using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Player player;
    public PausePanelB pausePanel;
    public PlayerMovement playerMove;
    private void Awake()
    {
        pausePanel = FindAnyObjectByType<PausePanelB>();
        playerMove = GetComponent<PlayerMovement>();
        player = GetComponent<Player>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject hittedObject = hit.collider.gameObject;
        if (hittedObject.CompareTag("DeathBlock") || hittedObject.CompareTag("Laser"))
        {
            player.isDead = true;
            //Destroy(gameObject);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
           /* losePanel.SetActive(true);
            GameObject canvas = losePanel.transform.parent.gameObject;*/

            playerMove.enabled = false;
            pausePanel.enabled = false;
        }
    }
}
