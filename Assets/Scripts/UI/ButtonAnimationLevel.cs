using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAnimationLevel : MonoBehaviour
{
    Button btn;
    Vector3 upScale = new Vector3(1.2f, 1.2f, 1);
    public int levelIndex;
    public SceneHandler sceneHandler;
    private void Awake()
    {
        sceneHandler = FindAnyObjectByType<SceneHandler>();
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Anim);
    }

    void Anim()
    {
        LeanTween.scale(gameObject, upScale, .1f);
        LeanTween.scale(gameObject, Vector3.one, .1f).setDelay(.1f);
    }

}
