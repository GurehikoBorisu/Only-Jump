using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationLevel : MonoBehaviour
{
    Button btn;
    Vector3 upScale = new Vector3(1.2f, 1.2f, 1);
    public int levelIndex;
    public LevelManager levelManager;
    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Anim);
    }

    void Anim()
    {
        LeanTween.scale(gameObject, upScale, .1f);
        LeanTween.scale(gameObject, Vector3.one, .1f).setDelay(.1f).setOnComplete(loadLevel);
    }

    void loadLevel()
    {
        levelManager.LoadLevel(levelIndex);
    }
}
