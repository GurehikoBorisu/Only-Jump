using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject losePanel;
    private void Awake()
    {

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject hittedObject = hit.collider.gameObject;
        if (hittedObject.CompareTag("DeathBlock") || hittedObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            losePanel.SetActive(true);
            GameObject canvas = losePanel.transform.parent.gameObject;
            canvas.GetComponent<PausePanelB>().enabled = false;
        }
    }
}
