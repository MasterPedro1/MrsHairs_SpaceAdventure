using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public string bgSound;
    public Sound[] sfx;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null) { instance = this; }
        else { 
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sfx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }

    private void Start()
    {
        Play(bgSound);
    }
    public void Play (string name)
    {
        Sound s =  Array.Find(sfx, Sound => Sound.fileName == name);
        if (s == null) { return; }
        s.source.Play();
    }
    //public float GetAudiotTime() { return GetComponent<AudioSource>().time; }
    //public float GetAudiotLength() { return GetComponent<AudioSource>().clip.length; }
    //public void CallEnd() { StartCoroutine(CountToEnd()); }
    //IEnumerator CountToEnd()
    //{
    //    while (GetComponent<AudioSource>().isPlaying) { yield return null; }
    //}
}
