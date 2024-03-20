using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audio;
    public AudioClip[] clip;
    AudioSource audioSource;
    void Awake()
    {
        audio = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(int clipIndex)
    {
        audioSource.PlayOneShot(clip[clipIndex]);
    }
}
