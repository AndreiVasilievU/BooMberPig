using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource soundSource;

    [SerializeField]
    AudioClip musicClip;
    [SerializeField]
    List <AudioClip> soundClips;
    
    private void Start()
    {
        PlayMusic();
    }
    public void PlayMusic()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySound(int i)
    {
        if(soundSource != null) 
        {
            soundSource.clip = soundClips[i];
            soundSource.PlayOneShot(soundClips[i]);
        }
        
    }
}
