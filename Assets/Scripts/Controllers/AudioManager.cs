using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager> {
    
    public bool music = true;
    public Sound[] sounds;
    
    void Awake()
    {   
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = 1;
            s.source.loop = s.loop;
        }
        music = PlayerPrefs.GetInt("music",1) == 1;
        if (music) Play("Background");
    }
    public void Play(string sound)
    {   
        if(!music) return;
        Sound s = Array.Find(sounds, item => item.name == sound);
        print(s);
        s.source.Play();
    }
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }
    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

}