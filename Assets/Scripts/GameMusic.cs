using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioClip WinPlay, DiePlay;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        _audio.Stop();
        _audio.PlayOneShot(WinPlay);
    }

    public void PlayDie() 
    {
        _audio.Stop();
        _audio.PlayOneShot(DiePlay);
    }
}
