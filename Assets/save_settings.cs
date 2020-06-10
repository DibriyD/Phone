using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class save_settings : MonoBehaviour
{
    public Slider slider;
    public static AudioMixer mixer;
    float value;
    // Start is called before the first frame update
    void Start()
    {
        mixer.GetFloat("Volume", out value);
        Debug.Log(mixer.GetFloat("Volume", out value));
        slider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
