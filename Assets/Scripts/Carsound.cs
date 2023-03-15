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
    public float minPitch = 0.8f; //the minimum pitch value
    public float maxPitch = 3f; //the maximum pitch value




    

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

public void PlayDrivesound(float speed, float maxspeed, float direction){
      speed = Mathf.Clamp(speed, 0f, maxspeed);
     float pitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed) * direction;
        DriveSource.pitch = pitch;
        DriveSource.clip = DriveSound;
        DriveSource.Play();


     
   
 
}

    public  void playIdle(){
        IdleSource.clip = idleSound;
        IdleSource.Play();
    }

}
