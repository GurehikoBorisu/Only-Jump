using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLoseOrWin : MonoBehaviour
{
    public GameObject background;
    public GameObject player;
    public List<GameObject> menus = new List<GameObject>();
    public List<Color> colors = new List<Color>();
    Image backgroundColor;
    Animator menuAnimator;
    public bool isLose;
    public bool isWin;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        backgroundColor = background.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLose)
        {
            i = 0;
            gameObject.GetComponent<GameMenu>().isWinOrLose = true;
            StartCoroutine("OpenMenu");
        }
        if (isWin)
        {
            i = 1;
            gameObject.GetComponent<GameMenu>().isWinOrLose = true;
            StartCoroutine("OpenMenu");
        }

    }
    IEnumerator OpenMenu()
    {
        Color color = colors[i];
        menuAnimator = menus[i].GetComponent<Animator>();
        menuAnimator.SetBool("MenuIsOpen", true);
        menuAnimator.SetBool("MenuIsClose", false);
        float startTime = Time.time;
        float duration = 1.25f;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            backgroundColor.color = Color.Lerp(backgroundColor.color, color, t);
            yield return null;
        }
        backgroundColor.color = color;
    }
}
