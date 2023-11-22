using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    AudioSource audioSource;
    public AudioMixerSnapshot Lose;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Lose.TransitionTo(0);
        audioSource.Play();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
