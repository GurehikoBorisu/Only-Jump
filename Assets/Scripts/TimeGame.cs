using UnityEngine;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour
{
    public float timeGame;

    int hourse;
    int minutes;

    public Text timeText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Minutes"))
            minutes = PlayerPrefs.GetInt("Minutes");

        if (PlayerPrefs.HasKey("Hourse"))
            hourse = PlayerPrefs.GetInt("Hourse");
    }


    void Update()
    {
        timeGame += Time.deltaTime;

        hourse = (int)timeGame / 3600;
        minutes = (int)timeGame % 3600 / 60;

        timeText.text = $"{hourse}.{minutes}";

        PlayerPrefs.SetInt("Minutes", minutes);
        PlayerPrefs.SetInt("Hourse", hourse);
    }
}
