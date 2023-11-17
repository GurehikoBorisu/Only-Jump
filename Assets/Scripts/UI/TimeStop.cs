using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{

    public void StoppedTime()
    {
        Time.timeScale = 0f;
    }
}
