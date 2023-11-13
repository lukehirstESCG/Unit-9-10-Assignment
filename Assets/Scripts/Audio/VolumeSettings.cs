using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer master;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TextMeshProUGUI MusicVolText;
    public TextMeshProUGUI SFXVolText;

    public const string MIXER_MUSIC = "MusicVol";
    public const string MIXER_SFX = "SFXVol";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    void SetMusicVolume(float value)
    {
        master.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);

        MusicVolText.text = value.ToString("0.00");
    }

    void SetSFXVolume(float value)
    {
        master.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);

        SFXVolText.text = value.ToString("0.00");
    }
}
