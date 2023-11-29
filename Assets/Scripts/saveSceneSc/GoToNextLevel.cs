using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public void UnlockLevel(int currentlvl)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevels = PlayerPrefs.GetInt("levels", 1);

        if (currentLevel >= unlockedLevels)
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }

      
        SceneManager.LoadScene(currentLevel + currentlvl);
    }
}
