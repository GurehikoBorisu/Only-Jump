using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject door;
    private int healths;

    void Start()
    {
        
    }

    void Update()
    {
        Kill();
    }

    public void Kill()
    {
        if (healths == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "1")
        {
            int damage = 100;
            healths -= damage;
        }
    }
}
