using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject loseMenu;
    private void Awake()
    {
        //transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject hittedObject = hit.collider.gameObject;
        if (hittedObject.CompareTag("DeathBlock") || hittedObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            loseMenu.SetActive(true);
        }
    }
}
