using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelUnLock;
    public Button[] buttons;

    void Start()
    {
        levelUnLock = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnLock; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("levels", 1);
        SceneManager.LoadScene(0);
    }
}

