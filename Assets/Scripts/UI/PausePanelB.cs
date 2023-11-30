using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class PausePanelB : MonoBehaviour
{
    public GameObject pausePanel;
    [SerializeField] KeyCode keyMenuPaused;

    [SerializeField] RectTransform pausePanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuraction;
    [SerializeField] CanvasGroup canvasGroup; // Dark panel canvas group

    public bool isMenuPaused = false;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;

    private void Start()
    {
        pausePanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }


        ActiveMenu();
    }
    public async void ActiveMenu()
    {
        if (isMenuPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            InMenu.TransitionTo(1.5f);
            Cursor.lockState = CursorLockMode.None;
            PausePanelIntro();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Normal.TransitionTo(1.5f);
            Time.timeScale = 1f;
            await PausePanelOutro();
        }
    }

    public void LoadMenu()
    { 
        Time.timeScale = 1;
    }
    public void Restart()
    {
        PlayerPrefs.SetFloat("posX", 0);
        PlayerPrefs.SetFloat("posY", 0);
        PlayerPrefs.SetFloat("posZ", 0);
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
