using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDoor : MonoBehaviour
{
    Animator anim;
    AudioSource aSource;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
        SoundManager.instance.PlaySound("sound_garage_door", aSource);
    }

    public void SoundQueue()
    {
       
        Debug.Log("Played sound");
    }
}
