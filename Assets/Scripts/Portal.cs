using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 boxSize;
    public LayerMask layer;
    public GameObject player;
    public Vector3 newPlayerTransform;
    void Start()
    {

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
    private void Update()
    {
        if (Physics.CheckBox(transform.position, boxSize, new Quaternion(0, 0, 0, 0), layer))
        {
            StartCoroutine("Teleport");
            Debug.Log("New Vegas");
        }
    }
    IEnumerator Teleport()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return null;
        player.transform.position = newPlayerTransform;
        yield return null;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
