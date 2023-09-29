using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{
    public Text[] profileText;

    public string[] engText;
    public string[] ukrText;

    public int language;

    public AudioSource click;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetInt("Language");
        }
    }

    void Start()
    {
        if (language == 0)
        {
            profileText[0].text = engText[0].ToString(); 
        }

        if (language == 1)
        {
            profileText[1].text = engText[1].ToString();
        }
    }

    private void Update()
    {
        if (language == 0)
        {
            profileText[0].text = engText[0].ToString();
            profileText[1].text = engText[1].ToString();
        }

        if (language == 1)
        {
            profileText[0].text = ukrText[0].ToString();
            profileText[1].text = ukrText[1].ToString();
        }
    }


    public void OnEngButton()
    {
        click.Play();
        language = 0;
        PlayerPrefs.SetInt("Language", language);
    }

    public void OnUkrButton()
    {
        click.Play();
        language = 1;
        PlayerPrefs.SetInt("Language", language);
    }
}
