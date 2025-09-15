using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : UIPanel
{
    [SerializeField] private Button _closeButton;

    [SerializeField] private AudioMixer _mainAudioMixer;
    [SerializeField] private AudioSource _audioSourceVoice;
    [SerializeField] private AudioSource _audioSourceVolume;

    [SerializeField] private Scrollbar _masterSoundVolume;
    [SerializeField] private Scrollbar _effectsSoundVolume;
    [SerializeField] private Scrollbar _voiceSoundVolume;

    [SerializeField] private Toggle _howToPlayToggle;

    [SerializeField] private TMP_Dropdown _languageDropdown;

    private AudioClip[] voiceClips;
    private AudioClip[] effectsClips;

    public static event Action ChangeLanguage;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Hide);

        _masterSoundVolume.onValueChanged.AddListener(MasterVolumeChanged);
        _effectsSoundVolume.onValueChanged.AddListener(EffectsVolumeChanged);
        _voiceSoundVolume.onValueChanged.AddListener(VoiceVolumeChanged);

        _howToPlayToggle.onValueChanged.AddListener(SetHowToPlay);

        _languageDropdown.onValueChanged.AddListener(SwitchLanguage);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Hide);

        _masterSoundVolume.onValueChanged.RemoveListener(MasterVolumeChanged);
        _effectsSoundVolume.onValueChanged.RemoveListener(EffectsVolumeChanged);
        _voiceSoundVolume.onValueChanged.RemoveListener(VoiceVolumeChanged);

        _howToPlayToggle.onValueChanged.RemoveListener(SetHowToPlay);

        _languageDropdown.onValueChanged.RemoveListener(SwitchLanguage);
    }

    public void SetStart()
    {
        _mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(_masterSoundVolume.value) * 20);
        _mainAudioMixer.SetFloat("EffectsVolume", Mathf.Log10(_effectsSoundVolume.value) * 20);
        _mainAudioMixer.SetFloat("VoiceVolume", Mathf.Log10(_voiceSoundVolume.value) * 20);

        voiceClips = Resources.LoadAll<AudioClip>("Sounds/Cards/Deployment/");
        effectsClips = Resources.LoadAll<AudioClip>("Sounds/Cards/StartOrder/");

        _howToPlayToggle.isOn = HowToPlay.Instance.IsHowToPlay;

        if (PlayerPrefs.HasKey("Language"))
            LocalizationManager.Instance.Language = PlayerPrefs.GetString("Language");
        else
            LocalizationManager.Instance.Language = "en";

        if (_languageDropdown != null)
        {
            switch (LocalizationManager.Instance.Language)
            {
                case "en":
                    _languageDropdown.value = 0;
                    break;

                case "ru":
                    _languageDropdown.value = 1;
                    break;
            }
        }
    }

    public void SettingsShow()
    {
        _masterSoundVolume.value = Mathf.Pow(10, GetFloatFromAudioMixer("MasterVolume") / 20);
        _effectsSoundVolume.value = Mathf.Pow(10, GetFloatFromAudioMixer("EffectsVolume") / 20);
        _voiceSoundVolume.value = Mathf.Pow(10, GetFloatFromAudioMixer("VoiceVolume") / 20);

        Show();
    }

    private void SwitchLanguage(int value)
    {
        switch (value)
        {
            case 0:
                LocalizationManager.Instance.Language = "en";
                break;

            case 1:
                LocalizationManager.Instance.Language = "ru";
                break;
        }

        PlayerPrefs.SetString("Language", LocalizationManager.Instance.Language);
        PlayerPrefs.Save();

        ChangeLanguage.Invoke();

        LocalizedText[] texts = FindObjectsOfType<LocalizedText>();
        foreach (var text in texts)
        {
            text.UpdateText();
        }
    }

    private void MasterVolumeChanged(float value)
    {
        _mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);

        PlayRandomSound(_audioSourceVoice, true);
    }

    private void EffectsVolumeChanged(float value)
    {
        _mainAudioMixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);

        PlayRandomSound(_audioSourceVolume, false);
    }

    private void VoiceVolumeChanged(float value)
    {
        _mainAudioMixer.SetFloat("VoiceVolume", Mathf.Log10(value) * 20);

        PlayRandomSound(_audioSourceVoice, true);
    }

    private void PlayRandomSound(AudioSource audioSource, bool isVoice)
    {
        if (isVoice)
            audioSource.clip = voiceClips[UnityEngine.Random.Range(0, voiceClips.Length)];

        else
            audioSource.clip = effectsClips[UnityEngine.Random.Range(0, effectsClips.Length)];

        audioSource.Play();
    }

    private float GetFloatFromAudioMixer(string nameFloat)
    {
        float value;
        _mainAudioMixer.GetFloat(nameFloat, out value);
        return value;
    }

    private void SetHowToPlay(bool isTrue)
    {
        HowToPlay.Instance.SetIsHowToPlay(isTrue);
    }
}
