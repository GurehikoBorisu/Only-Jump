using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLose : MonoBehaviour
{
    public GameObject losePanel;

    private void Start()
    {
        losePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            losePanel.SetActive(true);
        }
    }
}
