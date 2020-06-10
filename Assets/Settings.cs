using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    public AudioMixer audioMixer;
    private float VolumeSliderGet;
    public Slider slider;
    float value;
    void Start()
    {
        slider.value = GetVolume();
    }
    void Update()
    {
        VolumeSliderGet = slider.value;
         SetVolume(VolumeSliderGet);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public float GetVolume()
    {
        audioMixer.GetFloat("Volume", out value);
        return value;
    }
}
