using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class PausePanelB : MonoBehaviour
{
    public float x, y, z;
    public GameObject player;
    [SerializeField] KeyCode keyMenuPaused;
    [SerializeField] RectTransform pausePanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuraction;
    [SerializeField] CanvasGroup canvasGroup; // Dark panel canvas group

    public bool isMenuPaused = false;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;

    private void Update()
    {
        ActiveMenu();
    }
    public async void ActiveMenu()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }

        if (isMenuPaused)
        {
            Time.timeScale = 0;
            InMenu.TransitionTo(0.65f);
            //InMenu.TransitionTo(1.5f);
            Cursor.lockState = CursorLockMode.None;
            player.layer = 0;
            PausePanelIntro();
        }
        else
        {
            player.layer = 8;
            Cursor.lockState = CursorLockMode.Locked;
            Normal.TransitionTo(0.65f);
            //Normal.TransitionTo(1.5f);
            Time.timeScale = 1f;
            await PausePanelOutro();
        }
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
    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }
    IEnumerator RestartCoroutine ()
    {
        PlayerPrefs.SetFloat("posX", x);
        PlayerPrefs.SetFloat("posY", y);
        PlayerPrefs.SetFloat("posZ", z);
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        isMenuPaused = false;
    }
    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuraction).SetUpdate(true);
        pausePanelRect.DOAnchorPosY(middlePosY, tweenDuraction).SetUpdate(true);
    }

    async Task PausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuraction).SetUpdate(true);
        await pausePanelRect.DOAnchorPosY(topPosY, tweenDuraction).SetUpdate(true).AsyncWaitForCompletion();
    }
}
