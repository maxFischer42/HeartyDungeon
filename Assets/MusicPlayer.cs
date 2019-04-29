using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip dungeonTheme;
    public AudioClip bossTheme;
    private AudioSource aud;


    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        ChangeSong(0); 
    }

    public void ChangeSong(int _songID)
    {
        aud.Stop();
        switch (_songID)
        {
            case 0:
                aud.clip = dungeonTheme;
                break;
            case 1:
                aud.clip = bossTheme;
                break;
        }
        aud.time = 0f;
        aud.Play();
    }
}
