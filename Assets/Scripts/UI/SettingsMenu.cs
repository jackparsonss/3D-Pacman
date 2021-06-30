using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        public AudioMixer volumeAudioMixer;
        public AudioMixer sfxAudioMixer;
        public TMP_Dropdown resolutionDropdown;

        private Resolution[] _resolutions;
        
        private void Start()
        {
            _resolutions = Screen.resolutions;
            
            resolutionDropdown.ClearOptions();

            List<string> options = GetResolutions();
            
            resolutionDropdown.AddOptions(options);
        }

        private List<string> GetResolutions()
        {
            List<string> options = new List<string>();
            
            int computerResolutionIndex = 0;
            for(int i = 0; i < _resolutions.Length; i++)
            {
                options.Add(_resolutions[i].width + " x " + _resolutions[i].height);

                
                if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
                {
                    computerResolutionIndex = i;
                }
            }
            resolutionDropdown.value = computerResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            return options;
        }

        public void SetVolume(float volume)
        {
            volumeAudioMixer.SetFloat("Volume", volume);
        }

        public void SetSfx(float volume)
        {
            sfxAudioMixer.SetFloat("Volume", volume);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void SetResolution(int resolutionIndex)
        {
            Screen.SetResolution(_resolutions[resolutionIndex].width, _resolutions[resolutionIndex].height, Screen.fullScreen);
        }
    }
}
