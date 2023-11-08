using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
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
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            pauseMenu.SetActive(false);
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
