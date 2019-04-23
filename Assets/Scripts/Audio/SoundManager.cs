using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singeleton
    public static SoundManager instance;

    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    public Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();
    public List<Sound> soundList = new List<Sound>();

    private void Awake()
    {
        InitSingleton();

        foreach (Sound s in soundList)
        {
            InitSound(s);
        }
    }

    public void InitSound(Sound newSound)
    {
        if (!sounds.ContainsKey(newSound.soundSlug))
        {
            sounds.Add(newSound.soundSlug, newSound);
            Debug.Log("Added sound: " + newSound.soundSlug);
        }
        else
        {
            Debug.Log("Sound already exists!");
        }
    }

    public void PlaySound(string soundName, AudioSource audioSource)
    {
        foreach (KeyValuePair<string, Sound> keyValuePair in sounds) 
        {
            if(keyValuePair.Key == soundName)
            {
                Sound soundToPlay = keyValuePair.Value;
                audioSource.PlayOneShot(soundToPlay.sound);
                Debug.Log("Playing: " + soundName);
            }
        }
    }
}
