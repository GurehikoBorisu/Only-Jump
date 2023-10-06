using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwardTime : MonoBehaviour
{
    public float time;
    public float currentTime;

    public Text timeText;

    public bool isTime = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("time"))
            time = PlayerPrefs.GetFloat("time");
    }

    private void Update()
    {
        if (isTime) 
        {
            time += Time.deltaTime;
            PlayerPrefs.SetFloat("time", time);

            currentTime += Time.time;
        }
        else
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            isTime = false;

            if (time >= currentTime)
            {
                timeText.text = time.ToString();
                PlayerPrefs.SetFloat("time", time);
            }
            else
            {
               time = currentTime;
               timeText.text = time.ToString();
               PlayerPrefs.SetFloat("time", time);
            }
        }
    }
}
