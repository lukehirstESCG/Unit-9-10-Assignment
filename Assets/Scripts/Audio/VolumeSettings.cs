using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer master;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Awake()
    {
        musicSlider.onValueChanged.AddListener();
        sfxSlider.onValueChanged.AddListener();
    }
}
