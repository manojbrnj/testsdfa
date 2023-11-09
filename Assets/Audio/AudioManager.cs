using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioClip[] sounds,effects;
    public AudioSource music,sfx,walk;
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
       // Debug.Log(name);
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
    public void PlaySfx(string name)
    {
        var sound = Array.Find(effects, s => s.name == name);
        if (sound == null)
        {
           // Debug.Log("Sfx not found", sound);
        }
        else
        {
            if (sound.name == "walk")
            {
              //  Debug.Log("PlayWalk");
                walk.PlayOneShot(sound);
            }
            if(sound.name == "Blast")
            sfx.PlayOneShot(sound);
        }
    }
 

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic("Play2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
