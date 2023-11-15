using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    public List<Scene> levels = new List<Scene>();
    public int nextLevelNumber;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            pauseMenu.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponentInChildren<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            pauseMenu.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponentInChildren<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isOpen = false;
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(levels[nextLevelNumber].buildIndex);
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponentInChildren<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isOpen = false;
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
