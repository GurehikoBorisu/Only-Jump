using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TestLose : MonoBehaviour
{
    public GameObject losePanel;
    public AudioSource loseAudioSource;

    bool isActive = false;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;
    public AudioMixerSnapshot Lose;

    private void Start()
    {
        losePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T) && !isActive)
        {
            isActive = true;
            Lose.TransitionTo(0);
            losePanel.SetActive(true);
            loseAudioSource.Play();
        }
    }
    void PlayerLose()
    {
        isActive = true;
        losePanel.SetActive(true);
        loseAudioSource.Play();
    }
}
