using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string fileName;
    public AudioClip clip;
    public bool loop;
    public AudioMixerGroup mixerGroup;
    [Range (0f, 1f)]
    public float volume;
    [Range (0.1f, 3f)]
    public float pitch;
    [Range (0.1f, 1f)]
    public float spatialBlend;
    public AudioSource source;



    

}
