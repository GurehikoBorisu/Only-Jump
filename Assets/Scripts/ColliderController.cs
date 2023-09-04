using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public bool[] isButtons;
    public GameObject[] door;
    public int count;

    void Start()
    {
        
    }

    void Update()
    {
        //if (isButtons[0] && isButtons[1])
        //{
        //    isButtons[0] = true;
        //    isButtons[1] = true;
        //    Destroy(door[0]);
        //}

        if (count >= 2)
        {
            isButtons[0] = true;
            isButtons[1] = true;
            count = 0;
            Destroy(door[0]);
        }

        if (isButtons[2] && count >= 1)
        {
            Destroy(door[1]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Buttons_1")
        {
            count += 1;
            isButtons[0] = true;
            Debug.Log(count);
            Debug.Log(isButtons[0]);
            
        }

        if (collision.gameObject.tag == "Buttons_2")
        {
            count += 1;
            isButtons[1] = true;
            Debug.Log(count);
            Debug.Log(isButtons[1]);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Buttons_1")
        {
            isButtons[0] = false;
            isButtons[2] = true;
            count += 1;
        }

        if (collision.gameObject.tag == "Buttons_2")
        {
            isButtons[1] = false;
        }
    }
}
