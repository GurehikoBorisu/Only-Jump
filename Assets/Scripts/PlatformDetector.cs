using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Platform"))
        {
            gameObject.GetComponent<PlayerMovement>().isOnPlatform = true;
        }
        else
        {
            gameObject.GetComponent<PlayerMovement>().isOnPlatform = false;
        }
    }
}
