﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    bool can_play;
    public AudioMixerGroup mixer_forAll;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
           s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
           
            s.source.outputAudioMixerGroup = mixer_forAll;
        }
    }

    public void Play(string name)
    {
      Sound s= Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
            s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
}
