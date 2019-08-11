using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMaster : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioSource audioSource;

    public void PlayMainMenuMusic()
    {
        audioSource.clip = menuMusic;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }
}