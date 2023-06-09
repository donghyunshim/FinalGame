using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanagermusic : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    

    public AudioClip background;


    void Start()
    {
        musicSource.clip = background;
        musicSource.volume = .1f;
        musicSource.Play();
    }
}