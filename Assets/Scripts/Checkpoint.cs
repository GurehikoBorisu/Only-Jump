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
    public LayerMask layer;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 2, 0), boxSize);
    }
    private void Update()
    {
        if (Physics.CheckBox(transform.position + new Vector3(0, 2, 0), boxSize, new Quaternion(0,0,0,0), layer))
        {
            PlayerPrefs.SetFloat("posX", posX);
            PlayerPrefs.SetFloat("posY", posY);
            PlayerPrefs.SetFloat("posZ", posZ);
            Debug.Log($"{PlayerPrefs.GetFloat("posX")},{PlayerPrefs.GetFloat("posY")},{PlayerPrefs.GetFloat("posZ")}");
        }
    }
}
