using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI {
    public class SettingsMenu : MonoBehaviour{
        [SerializeField] private AudioMixer audioMixer;
        private Resolution[] resolutions;
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Toggle fullscreenToggle;
        [SerializeField] private TMP_Dropdown qualityDropdown;

    
        private void Start() {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            var options = resolutions.Select(item => $"{item.width}x{item.height}").ToList();
            resolutionDropdown.AddOptions(options);
        
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 0) == 1;
            qualityDropdown.value = PlayerPrefs.GetInt("Quality", 0);
            
            var defaultResolution = resolutions.First(res => res is { width: 1920, height: 1080 });
            var resolutionIndex = Array.IndexOf(resolutions, defaultResolution);

            Screen.SetResolution(defaultResolution.width, defaultResolution.height, Screen.fullScreen); 
            resolutionDropdown.value = resolutionIndex;
            SetResolution(resolutionIndex);
        }
        public void SetVolume(float volume) {
            audioMixer.SetFloat("Volume", volume);
        
            PlayerPrefs.SetFloat("Volume", volume);
        }

        public void SetQuality(int quality) {
            QualitySettings.SetQualityLevel(quality, true);
        
            PlayerPrefs.SetInt("Quality", quality);
        }

        public void SetFullscreen(bool fullscreen) {
            Screen.fullScreen = fullscreen;
        
            PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
        }
    
        public void SetResolution(int resolutionIndex) {
            Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
        
        
            PlayerPrefs.SetInt("Resolution", resolutionIndex);
        }
    }
}