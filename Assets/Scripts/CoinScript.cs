using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float sphereRadius;
    public LayerMask layer;
    public GameObject player;
    bool isPlayer = false;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, sphereRadius, layer) && !isPlayer)
        {
            isPlayer = true;
            StartCoroutine("ReturnToMainPlatform");
        }
    }
    IEnumerator ReturnToMainPlatform()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return null;
        player.transform.position = new Vector3(0, 3.25f, 0);
        yield return null;
        player.GetComponent<PlayerMovement>().enabled = true;
        int coins = PlayerPrefs.GetInt("coins") + 1;
        Debug.Log($"CCC:{coins}");
        PlayerPrefs.SetInt("coins", coins);
    }
}
