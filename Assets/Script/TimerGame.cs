using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGame : MonoBehaviour
{
    public static float timeGame;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("TimeGame"))
        {
            timeGame = PlayerPrefs.GetFloat("TimeGame");
        }
    }

    void Start()
    {
        PlayerPrefs.SetFloat("TimeGame", timeGame);
    }

    void Update()
    {
        timeGame += Time.deltaTime;
        PlayerPrefs.SetFloat("TimeGame", timeGame);
    }
}
