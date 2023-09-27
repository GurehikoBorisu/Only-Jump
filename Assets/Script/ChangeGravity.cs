using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    bool gravity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        gravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gravity && isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            Physics.gravity = new Vector3(0,9.81f,0);
            StartCoroutine("Rotate");
            gravity = false;
            isGrounded = false;
        }
        else if (!gravity && isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            StartCoroutine("Rotate");
            gravity = true;
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }
    IEnumerator Rotate()
    {
        for(int i = 0; i < 90; i++)
        {
            transform.Rotate(0, 0, 2f);
            yield return null;
        }
    }
}
