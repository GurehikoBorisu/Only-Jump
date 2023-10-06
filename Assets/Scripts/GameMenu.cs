using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics.Contracts;

public class GameMenu : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject background;
    public bool isWinOrLose;
    public List<string> levels = new List<string>();
    public int nextLevelNumber;
    public GameObject player;
    public GameObject menu;
    PlayerController playerController;
    Image backgroundColor;
    Image blackScreenColor;
    Animator menuAnimator;
    string levelTitle;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        //playerController= player.GetComponent<PlayerController>();
        backgroundColor = background.GetComponent<Image>();
        blackScreenColor = blackScreen.GetComponent<Image>();   
        menuAnimator = menu.GetComponent<Animator>();
        StartCoroutine("OpenLevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen && !isWinOrLose)
        {
            //playerController.enabled = false;
            menuAnimator.SetBool("MenuIsOpen",true);
            menuAnimator.SetBool("MenuIsClose", false);
            StartCoroutine("OpenMenu");
        }
        else if(Input.GetKeyDown(KeyCode.E) && isOpen && !isWinOrLose)
        {
            //playerController.enabled = true;
            menuAnimator.SetBool("MenuIsOpen", false);
            menuAnimator.SetBool("MenuIsClose", true);
            StartCoroutine("CloseMenu");
        }
    }
    IEnumerator OpenMenu()
    {
        float startTime = Time.time;
        float duration = 1.25f;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            backgroundColor.color = Color.Lerp(backgroundColor.color, new Color(0.5f, 0.5f, 0.5f, 0.75f), t);
            yield return null;
        }
        backgroundColor.color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
        isOpen = true;
    }
    IEnumerator CloseMenu()
    {
        float startTime = Time.time;
        float duration = 1;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            backgroundColor.color = Color.Lerp(backgroundColor.color, new Color(0.5f, 0.5f, 0.5f, 0), t);
            yield return null;
        }
        backgroundColor.color = new Color(0.5f, 0.5f, 0.5f, 0);
        isOpen = false;
    }
    IEnumerator CloseLevel()
    {
        background.SetActive(false);
        float startTime = Time.time;
        float duration = 1;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            blackScreenColor.color = Color.Lerp(blackScreenColor.color, Color.black, t);
            yield return null;
        }
        blackScreenColor.color = Color.black;
        SceneManager.LoadScene(levelTitle);
    }
    IEnumerator OpenLevel()
    {
        float startTime = Time.time;
        float duration = 1;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            blackScreenColor.color = Color.Lerp(blackScreenColor.color, new Color(0,0,0,0), t);
            yield return null;
        }
        blackScreenColor.color = new Color(0, 0, 0, 0);
    }
    public void Continue()
    {
        //playerController.enabled = true;
        menuAnimator.SetBool("MenuIsOpen", false);
        menuAnimator.SetBool("MenuIsClose", true);
        StartCoroutine("CloseMenu");
    }
    public void Again()
    {
        levelTitle = SceneManager.GetActiveScene().name;
        StartCoroutine("CloseLevel");
    }
    public void Exit()
    {
        levelTitle = "MainMenu";
        StartCoroutine("CloseLevel");
    }
    public void NextLevel()
    {
        levelTitle = levels[nextLevelNumber];
        StartCoroutine("CloseLevel");
    }
}
