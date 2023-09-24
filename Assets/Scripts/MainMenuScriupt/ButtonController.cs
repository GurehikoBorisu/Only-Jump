using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject[] panels;
    public int numberScene;

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
        panels[0].SetActive(!panels[0].activeSelf);
    }

    public void SettingButton()
    {
        panels[1].SetActive(!panels[1].activeSelf);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
