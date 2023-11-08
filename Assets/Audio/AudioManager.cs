using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioClip[] sounds,effects;
    public AudioSource music,sfx;
    private void Awake()
    {
   if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Debug.Log(name);
        var sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.Log("Sound not foundsad", sound);
        }
        else
        {
            music.clip = sound;
            music.Play();
        }
    }
    public void PlaySfx(string name,float time)
    {
        var sound = Array.Find(effects, s => s.name == name);
        if (sound == null)
        {
            Debug.Log("Sfx not found", sound);
        }
        else
        {
            Debug.Log("Blast");
             //  sfx.clip = sound;
            sfx.PlayOneShot(sound,time);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic("Play1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
