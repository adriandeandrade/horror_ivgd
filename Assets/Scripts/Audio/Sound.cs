using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip sound;
    public string soundName;
    public string soundSlug;
    public float volume;
    public float pitch;

    public Sound(AudioClip clip, float _volume, float _pitch, string _soundName, string _soundSlug)
    {
        sound = clip;
        volume = _volume;
        pitch = _pitch;
        soundName = _soundName;
        soundSlug = _soundSlug;
    }
}
