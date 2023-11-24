using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCheck : MonoBehaviour , IPointerEnterHandler
{
    public GameObject eventSystem;
    public int levelNumber;
    LoadLevel loadLevel;
    //MainMenu menu;
    void Start()
    {
        loadLevel = eventSystem.GetComponent<LoadLevel>();
        //menu = eventSystem.GetComponent<MainMenu>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(gameObject.tag == "LoadLevelButton")
        {
            loadLevel.levelNumber = levelNumber;
            //menu.z = z;
        }
    }
}
