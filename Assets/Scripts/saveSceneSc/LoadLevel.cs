using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Button[] butt;
    public int sceneCount;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", -1);
        }

        switch (PlayerPrefs.GetInt("Level"))
        {
            case -1:
                butt[0].interactable = true;
                butt[1].interactable = false;
                butt[2].interactable = false;
                butt[3].interactable = false;
                butt[4].interactable = false;
                break;

            case 0:
                butt[0].interactable = true;
                butt[1].interactable = true;
                butt[2].interactable = false;
                butt[3].interactable = false;
                butt[4].interactable = false;
                break;

            case 1:
                butt[0].interactable = true;
                butt[1].interactable = true;
                butt[2].interactable = true;
                butt[3].interactable = false;
                butt[4].interactable = false;
                break;

            case 2:
                butt[0].interactable = true;
                butt[1].interactable = true;
                butt[2].interactable = true;
                butt[3].interactable = true;
                butt[4].interactable = false;
                break;

            case 3:
                butt[0].interactable = true;
                butt[1].interactable = true;
                butt[2].interactable = true;
                butt[3].interactable = true;
                butt[4].interactable = true;
                break;
        }
    }

    public void load1()
    {
        SceneManager.LoadScene(sceneCount);
    }

    public void load2()
    {
        SceneManager.LoadScene(sceneCount);
    }

    public void load3()
    {
        SceneManager.LoadScene(sceneCount);
    }

    public void load4()
    {
        SceneManager.LoadScene(sceneCount);
    }

    public void load5()
    {
        SceneManager.LoadScene(sceneCount);
    }
}
