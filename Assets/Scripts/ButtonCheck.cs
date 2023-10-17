using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCheck : MonoBehaviour , IPointerEnterHandler
{
    public int x, y, z, w, q;
    public GameObject eventSystem;
    MainMenu menu;
    void Start()
    {
        menu = eventSystem.GetComponent<MainMenu>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(gameObject.tag == "LoadLevelButton")
        {
            menu.z = z;
        }
        else if (gameObject.tag == "OpenAnotherPanelButton")
        {
            menu.x = x;
            menu.y = y;
        }
    }
}
