using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    public LoadGame loadGame;

    private void Start()
    {
        if (loadGame == null)
            loadGame = FindObjectOfType<LoadGame>();

        fader.gameObject.SetActive(true);

        // SCALE
        fader.DOScale(Vector3.zero, 0).SetUpdate(true);
        fader.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutQuad).SetUpdate(true).OnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    public void OpenMenuScene()
    {
        fader.gameObject.SetActive(true);

        // SCALE
        fader.DOScale(Vector3.zero, 0).SetUpdate(true);
        fader.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad).SetUpdate(true).OnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    public void OpenGameScene()
    {
        fader.gameObject.SetActive(true);

        // SCALE
        fader.DOScale(Vector3.zero, 0).SetUpdate(true);
        fader.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad).SetUpdate(true).OnComplete(() =>
        {
            LoadGameLevel();
        });
    }

    public void LoadGameLevel()
    {
        loadGame.LoadGameA();
    }
}

