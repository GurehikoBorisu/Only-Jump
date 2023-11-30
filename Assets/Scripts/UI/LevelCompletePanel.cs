using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class LevelCompletePanel : MonoBehaviour
{
    //public bool islevelComletePanel;
    [SerializeField] private RectTransform levelComletePanelRect;
    [SerializeField] private float topPanelY, middlePanelY;
    [SerializeField] private float tweenDuration;
    [SerializeField] private CanvasGroup canvasGroup;

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot InMenu;

    public GoToNextLevel nextLevel;
    public GameObject player;
    AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nextLevel = FindObjectOfType<GoToNextLevel>();
        player.SetActive(false);
        audioSource.Play();
        Time.timeScale = 0;
        InMenu.TransitionTo(0.25f);
        Cursor.lockState = CursorLockMode.None;
        PlayWinPanelIntro();
    }
    // Update is called once per frame
    //void Update()
    //{
        //HandleMenuActivation();
    //}

    //public async void HandleMenuActivation()
    //{
        //if (islevelComletePanel)
        //if(islevelComleted)
        //{
        //    Time.timeScale = 0;
        //    InMenu.TransitionTo(1.5f);
        //    Cursor.lockState = CursorLockMode.None;
        //    PlayPausePanelIntro();
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Normal.TransitionTo(1.5f);
        //    Time.timeScale = 1f;
        //    await PlayPausePanelOutro();
        //}
    //}

    public void LoadMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        nextLevel.UnlockLevel(0);
    }


    public void Restart()
    {
        Cursor.lockState = CursorLockMode.None;
        nextLevel.UnlockLevel(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //void PlayPausePanelIntro()
    void PlayWinPanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        levelComletePanelRect.DOAnchorPosY(middlePanelY, tweenDuration).SetUpdate(true);
    }
    public void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(nextLevel);
    }

    //async Task PlayPausePanelOutro()
    //{
    //    canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
    //    await levelComletePanelRect.DOAnchorPosY(topPanelY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    //}
}
