using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject door;
    public int healths = 100;    

    void Update()
    {
        Kill();
    }

    public void Kill()
    {
        if (healths <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.tag == "1")
        {
            Destroy(door);
        }

        if (other.gameObject.tag == "2")
        {
            
            healths -= 100;
            Destroy(other.gameObject);
        }
    }
}
