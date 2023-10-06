using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowPlayerCanDeads : MonoBehaviour
{
    // Start is called before the first frame update
    public float yMax;
    public float yMin;
    public GameObject eventSystem;
    PlayerLoseOrWin playerLoseOrWin;
    void Start()
    {
        playerLoseOrWin = eventSystem.GetComponent<PlayerLoseOrWin>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= yMax)
        {
            playerLoseOrWin.isLose = true;
        }
        else if(transform.position.y <= yMin)
        {
            playerLoseOrWin.isLose = true;
        }
    }
}
