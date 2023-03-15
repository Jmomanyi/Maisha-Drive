using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carsound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource hornSource;
    public AudioSource ignitionSource;
    public AudioClip ignitionSound;
    public AudioClip hornSound;
    public AudioClip drivingSound;

    public void PlayIgnitionSound()
    {
       ignitionSource.clip = ignitionSound;
        ignitionSource.Play();
    }

    public void PlayHornSound()
    {
        hornSource.clip = hornSound;
        hornSource.Play();
    }

    public void PlayDrivingSound()
    {
        audioSource.clip = drivingSound;
        audioSource.Play();
    }

}
