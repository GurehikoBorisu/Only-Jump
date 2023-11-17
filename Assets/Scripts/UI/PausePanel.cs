using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject pauseMenuUI;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;
    // Update is called once per frame
    private void Update()
    {
        ActiveMenu();
    }
    void ActiveMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = !GameIsPaused;
        }

        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(true);
           // Time.timeScale = 0;
            InMenu.TransitionTo(1.5f);
            GameIsPaused = true;
         //   Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            //Time.timeScale = 1;
            Normal.TransitionTo(1.5f);
            GameIsPaused = false;
          //  Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Normal.TransitionTo(1.5f);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
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
