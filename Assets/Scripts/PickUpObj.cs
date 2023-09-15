using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObj : MonoBehaviour
{
    private float distance = 15f;
    private float distanceView = 3f;
    public bool isHand;
    public Transform pos;
    private Rigidbody rb;
    public GameObject rayText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isHand == true)
        {
            rayText.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            rb.isKinematic = true;
            isHand = true;
            rb.MovePosition(pos.position);
        }
    }

    private void OnMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distanceView))
        {
            rayText.SetActive(true);
        }
        else
        {
            rayText.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            rayText.SetActive(false);
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
