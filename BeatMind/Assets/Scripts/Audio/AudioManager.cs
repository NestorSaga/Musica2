using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [Range(0,1)]public float generalVol;

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;            
        }
    }

    private void Start()
    {
        Play("MenuMusic");
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * generalVol;
        s.source.pitch = 1;

        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }

    public void StopAll()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.Stop();
        }
    }
}
