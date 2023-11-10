using UnityEngine;
using UnityEngine.UI;


public class AvardTime : MonoBehaviour
{
    public float time;
    public float currentTime;

    public Text timeText;

    public bool isTime = true;

    private void Start()
    {
        currentTime = 0;
    }

    private void Update()
    {
        if (isTime == true)
        {
            time += Time.deltaTime;
            timeText.text = time + "секунд/second".ToString();

            currentTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            if (PlayerPrefs.HasKey("time"))
                time = PlayerPrefs.GetFloat("time");

            isTime = false;
            if (time >= currentTime)
            {
                time = currentTime;
                float res = ((float)(int)(time * 100)) / 100;
                timeText.text = res + "секунд/second".ToString();
                PlayerPrefs.SetFloat("time", time);
            }
            else
            {
                float res = ((float)(int)(time * 100)) / 100;
                timeText.text = res + "секунд/second".ToString();
                PlayerPrefs.SetFloat("time", time);
            }
        }
    }
}
