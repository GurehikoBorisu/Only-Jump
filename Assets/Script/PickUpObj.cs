using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PickUpObj : MonoBehaviour
{
    private float distance = 3f;    
    private float distanceView = 3f;
    public bool isHand;
    public Transform pos;
    private Rigidbody rb;
    public GameObject rayText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = GameObject.FindGameObjectWithTag("hand").transform; // ---добавлено---
    }
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            rayText.SetActive(false);
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
        }
        else
        {

        }
    }

    //private void OnMouseOver()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, distanceView))
    //    {
    //        rayText.SetActive(true);
    //    }
    //    else
    //    {
    //        rayText.SetActive(false);
    //    }
    //}

    private void OnMouseEnter()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distanceView))
        {
            rayText.SetActive(true);
        }       
    }

    private void OnMouseExit()
    {
        if (distanceView < 4)
        {
            rayText.SetActive(false);
        }
    }

    private void Update()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.Q)) // ---изменено---
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rayText.SetActive(false);
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
