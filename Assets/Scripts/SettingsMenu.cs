using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour{
    [SerializeField] private AudioMixer audioMixer;
    private Resolution[] resolutions;
    [SerializeField] private TMP_Dropdown resolutionDropdown;


    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int quality) {
        QualitySettings.SetQualityLevel(quality, true);
    }

    public void SetFullscreen(bool fullscreen) {
        Screen.fullScreen = fullscreen;
    }

    private void Start() {
        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        var options = resolutions.Select(item => $"{item.width}x{item.height}").ToList();

        resolutionDropdown.AddOptions(options);
    }

    public void SetResolution(int resolutionIndex) {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
}