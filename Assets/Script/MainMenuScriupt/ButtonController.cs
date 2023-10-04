using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject[] panels;

    public int numberScene;

    [SerializeField] private Text TimeText;

    public AudioSource _click;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("TimeGame"))
        {
            TimerGame.timeGame = PlayerPrefs.GetFloat("TimeGame");
        }
    }

    void Start()
    {
        TimeText.text = ((int)TimerGame.timeGame / 60).ToString() + "хвилин/minutes";
    }

    void Update()
    {
        TimeText.text = ((int)TimerGame.timeGame / 60).ToString() + "хвилин/minutes";
    }

    public void Play()
    {
        SceneManager.LoadScene(numberScene);
    }

    public void PlayButton()
    {
        _click.Play();
        panels[0].SetActive(!panels[0].activeSelf);
    }

    public void SettingButton()
    {
        _click.Play();
        panels[1].SetActive(!panels[1].activeSelf);
    }

    public void ProfileButton()
    {
        _click.Play();
        panels[2].SetActive(!panels[2].activeSelf);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
