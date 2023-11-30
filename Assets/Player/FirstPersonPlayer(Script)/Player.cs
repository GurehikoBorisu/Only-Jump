using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelCompletePanel levelCompletePanel;
    public bool isDead;

    private void Awake()
    {
        levelCompletePanel = FindAnyObjectByType<LevelCompletePanel>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Finish1"))
        {
            //levelCompletePanel.islevelComletePanel = true;
        }
    }


}
