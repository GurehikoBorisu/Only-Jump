using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsUpdate : MonoBehaviour
{

    // Start is called before the first frame update
    public List<GameObject> portals = new List<GameObject>();
    void Start()
    {
        //PlayerPrefs.SetInt("coins",0);
        Debug.Log($"Coins count:{PlayerPrefs.GetInt("coins")}");
    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerPrefs.GetInt("coins")) 
        {
            case 0:
                portals[0].SetActive(true);
                portals[1].SetActive(false);
                portals[2].SetActive(false);
                portals[3].SetActive(false);
                break;
            case 1:
                portals[0].SetActive(false);
                portals[1].SetActive(true);
                portals[2].SetActive(false);
                portals[3].SetActive(false);
                break;
            case 2:
                portals[0].SetActive(false);
                portals[1].SetActive(false);
                portals[2].SetActive(true);
                portals[3].SetActive(false);
                break;
            case 3:
                portals[0].SetActive(false);
                portals[1].SetActive(false);
                portals[2].SetActive(false);
                portals[3].SetActive(true);
                break;
        }
    }
}
