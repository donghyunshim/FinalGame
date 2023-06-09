using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXqSource;

    public AudioClip background;
    public AudioClip pistolsound;
    public AudioClip automaticsound;
    public AudioClip shotgunsound;
    public AudioClip dodge;


    void Start()
    {
        musicSource.clip = background;
        musicSource.volume = .1f;
        SFXSource.volume = .1f;
        SFXqSource.volume = .4f;
        //musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFXq(AudioClip clip)
    {
        SFXqSource.PlayOneShot(clip);
    }
}