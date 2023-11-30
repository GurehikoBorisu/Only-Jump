using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject winPanel;
    private LevelCompletePanel levelCompletePanel;
    // Start is called before the first frame update
    void Start()
    {
        levelCompletePanel = FindAnyObjectByType<LevelCompletePanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Finish1"))
        {
            winPanel.SetActive(true);
            GameObject canvas = winPanel.transform.parent.gameObject;
            canvas.GetComponent<PausePanelB>().enabled = false;
        }
    }
}
