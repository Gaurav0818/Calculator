using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _audioSource;
    
    [SerializeField] List<AudioList> audioList = new List<AudioList>();
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(string name)
    {
        AudioList audio = audioList.Find(x => x.name == name);
        if (audio.audioClip)
        {
            _audioSource.clip = audio.audioClip;
            _audioSource.Play();
        }
    }
}

[Serializable]
public struct AudioList
{
    public string name;
    public AudioClip audioClip;
}