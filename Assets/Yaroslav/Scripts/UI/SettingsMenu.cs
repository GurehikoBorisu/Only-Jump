using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // public AudioMixer audioMixer;

    public AudioMixerGroup Mixer;
    public TMP_Dropdown resolutionDropdown;

    public AudioMixerGroup mixer;
    public Toggle musicToggle;
    public Slider volumeSlider;

    Resolution[] resolutions;

    private void Start()
    {
        if (musicToggle != null)
        {
            musicToggle.isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
            musicToggle.onValueChanged.AddListener(ToggleMusic);
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ToggleMusic(bool enabled)
    {
        float volume = enabled ? 0 : -80;
        mixer.audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }

    public void ChangeVolume(float volume)
    {
        float dbVolume = Mathf.Lerp(-80, 0, volume);
        mixer.audioMixer.SetFloat("MasterVolume", dbVolume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }


    public void SetQualty(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
