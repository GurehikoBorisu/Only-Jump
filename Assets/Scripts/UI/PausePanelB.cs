using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PausePanelB : MonoBehaviour
{
    public GameObject menuPaused;
    [SerializeField] KeyCode keyMenuPaused;
    bool isMenuPaused = false;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;

    private void Start()
    {
        menuPaused.SetActive(false);
    }

    private void Update()
    {
        ActiveMenu();
    }
    void ActiveMenu()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }

        if (isMenuPaused)
        {
            menuPaused.SetActive(true);
            InMenu.TransitionTo(1.5f);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            menuPaused.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Normal.TransitionTo(1.5f);
            Time.timeScale = 1f;
        }
    }
    public void Resume()
    {
        isMenuPaused = false;
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
}
