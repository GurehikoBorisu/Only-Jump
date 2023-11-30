using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShowTime : MonoBehaviour
{
    private int variableMinutes;
    private int variableHourse;

    //public Text TimeText;
    public TMP_Text timeText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Minutes"))
            variableMinutes = PlayerPrefs.GetInt("Minutes");
        if (PlayerPrefs.HasKey("Hourse"))
            variableHourse = PlayerPrefs.GetInt("Hourse");

        //TimeText.text = $"{variableHourse}.{variableMinutes}";
        timeText.text = $"{variableHourse}.{variableMinutes}";
    }

    private void Update()
    {
        //TimeText.text = $"{variableHourse}.{variableMinutes}/hourse";
        timeText.text = $"{variableHourse}.{variableMinutes}/hourse";
    }
}
