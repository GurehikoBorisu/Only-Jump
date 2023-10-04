using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpObj : MonoBehaviour
{
    private float distance = 3f;    
    private float distanceView = 3f;
    static bool isHand;
    public Transform pos;
    private Rigidbody rb;
    public GameObject rayText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = GameObject.FindGameObjectWithTag("hand").transform;
        isHand = false;
    }   

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance) && !isHand)
        {
            rayText.SetActive(false);
            rb.isKinematic = true;
            isHand = true;
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

    private void Update()
    {
        if (rb.isKinematic == true)
        {
            gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.Q) && isHand) 
            {
                rb.useGravity = true;
                isHand = false;
                rb.isKinematic = false;
                rayText.SetActive(false);
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
