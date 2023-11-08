using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float posX;
    public float posY;
    public float posZ;
    public Vector3 boxSize;
    bool playerDetected = false;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 2, 0), boxSize);
    }
    private void Update()
    {
        if (Physics.CheckBox(transform.position + new Vector3(0, 2, 0), boxSize) && !playerDetected)
        {
            Collider[] colliders = Physics.OverlapBox(transform.position, boxSize);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    PlayerPrefs.SetFloat("posX", posX);
                    PlayerPrefs.SetFloat("posY", posY);
                    PlayerPrefs.SetFloat("posZ", posZ);
                }
            }
        }
    }
}
