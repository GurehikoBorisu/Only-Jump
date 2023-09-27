using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject[] panels;
    public int numberScene;
    public AudioSource _click;

    void Start()
    {
        
    }

    void Update()
    {
        
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
