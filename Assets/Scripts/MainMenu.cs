using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public List<Scene> levelsList = new List<Scene>();
    public List<GameObject> panels = new List<GameObject>();
    public int x, y, z, w, q;
    void Start()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelsList[z].buildIndex);
    }
    public void OpenAnotherPanel()
    {
        panels[x].SetActive(false);
        panels[y].SetActive(true);
    }
}
