using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class LosePanel : MonoBehaviour
{

    [SerializeField] private RectTransform losePanelRect;
    [SerializeField] private float topPanelY, middlePanelY;
    [SerializeField] private float tweenDuration;
    [SerializeField] private CanvasGroup canvasGroup;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;

    private Player player;
    //    AudioSource audioSource;
    // public AudioMixerSnapshot Lose;

    private void Awake()
    {
            player = FindAnyObjectByType<Player>();
    }
    void Start()
    {
     //   audioSource = GetComponent<AudioSource>();
     //   Lose.TransitionTo(0);
     //   audioSource.Play();
    }

    private void Update()
    {
        HandleMenuActivation();
    }
    private async void HandleMenuActivation()
    {
        if (player.isDead)
        {
            Time.timeScale = 0;
            InMenu.TransitionTo(1.5f);
            Cursor.lockState = CursorLockMode.None;
            PlayPausePanelIntro();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Normal.TransitionTo(1.5f);
            Time.timeScale = 1f;
            await PlayPausePanelOutro();
        }
    }

    void PlayPausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        losePanelRect.DOAnchorPosY(middlePanelY, tweenDuration).SetUpdate(true);
    }

    async Task PlayPausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        await losePanelRect.DOAnchorPosY(topPanelY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
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

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}