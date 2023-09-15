using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }    

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
        }       
    }   

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

    private void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.G))
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rayText.SetActive(false);
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
