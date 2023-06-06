﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public AudioMixerGroup mixerGroup;

    public bool loop;

    public string fileName;

    public AudioClip clip;
    
    [Range (0f, 1f)]
    public float volume;
    [Range (0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
