using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public AudioSource clickSound;

    private void Start()
    {
        clickSound = FindObjectOfType<AudioSource>();
    }
    public void ClickSound()
    {
        //clickSound.pitch = Random.Range(0.9f, 1.1f);
        clickSound.Play();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT - 1");
        Application.Quit();
    }
}
