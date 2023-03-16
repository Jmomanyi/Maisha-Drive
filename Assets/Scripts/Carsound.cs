using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carsound : MonoBehaviour
{
    public AudioSource IdleSource;
    public AudioSource hornSource;
    public AudioSource ignitionSource;
    public AudioSource DriveSource;
    public AudioClip ignitionSound;
    public AudioClip DriveSound;
    public AudioClip hornSound;
    public AudioClip idleSound;
    public float minPitch = 0.05f;
     public float maxPitch=3f;
    public float pitchFactor = 0.1f;
    private float carPitch;

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

    public void PlayDrivesound(float speed, float m_verticalInput)
    {
        // Clamp the car pitch between a minimum and a maximum value
        carPitch = Mathf.Clamp(speed, minPitch, maxPitch);

        // Modify the car pitch based on the input direction
        carPitch += m_verticalInput * pitchFactor;

        // Set the source pitch to match the car pitch
        DriveSource.pitch = carPitch;

        // Play the sound clip without interrupting
        DriveSource.clip = DriveSound;
        DriveSource.Play();
        
    }

    public void playIdle()
    {
        IdleSource.clip = idleSound;
        IdleSource.Play();
    }
}
