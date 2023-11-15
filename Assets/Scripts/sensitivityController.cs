using UnityEngine;
using UnityEngine.UI;

public class sensitivityController : MonoBehaviour
{
    public Slider slider;
    public float currentSens;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Sensitivity"))
            currentSens = PlayerPrefs.GetFloat("Sensitivity");
    }

    private void Start()
    {
        slider.maxValue = 500f;
    }

    public void ChangeSens()
    {
        currentSens = slider.value;
        PlayerPrefs.SetFloat("Sensitivity", currentSens);
    }
}
