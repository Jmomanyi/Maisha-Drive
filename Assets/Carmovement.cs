using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Carmovement : MonoBehaviour
{


    public void getInput()
    {
        Horizontal_input = Input.GetAxis("Horizontal");
        Vertical_input = Input.GetAxis("Vertical");
        Brakes = Input.GetAxis("Jump");
    }

    public void update_healthbar()
    {
        Healthbar.fillAmount = currentHealth / maxhealth;
    }
 public void startCar(){
     if (Input.GetKeyDown(KeyCode.E)) {
            start=true;
     engineStartAudioSource.Play();
        idleAudioSource.Play();


          
           
     }
 }


    public void Steer()
    {
        Steer_Angle = maxSteerAngle * Horizontal_input;
        frontDriverW.steerAngle = Steer_Angle;
        frontPassengerW.steerAngle = Steer_Angle;
    }

    private void Accelerate()
    {
        frontDriverW.motorTorque = Vertical_input * motorForce;
        frontPassengerW.motorTorque = Vertical_input * motorForce;
if(start==true&&Vertical_input>0){
    driveAudioSource.Play();
}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            driveAudioSource.Stop();
        }
       

      

    }
//brke
    private void Brake()
    {
        if (Brakes>0)
        {
            frontDriverW.brakeTorque = brakePower;
            frontPassengerW.brakeTorque = brakePower;
            rearDriverW.brakeTorque = brakePower;
            rearPassengerW.brakeTorque = brakePower;
        }
        else
        {
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
         engineStartAudioSource = gameObject.AddComponent<AudioSource>();
engineStartAudioSource.clip = engineStartSound;

idleAudioSource = gameObject.AddComponent<AudioSource>();
idleAudioSource.clip = idle;

driveAudioSource = gameObject.AddComponent<AudioSource>();
driveAudioSource.clip = drive;

hornAudioSource = gameObject.AddComponent<AudioSource>();
hornAudioSource.clip = horn;

        // carRigidbody.centerOfMass=centerofMass.transform.localPosition;
        currentHealth = maxhealth;
    start=false;
        update_healthbar();

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }

    }

    void FixedUpdate()
    {

        startCar();
        getInput();
        Steer();
        Accelerate();
        Brake();
        UpdateWheelPoses();
        update_healthbar();
                              
    }
//collision detection
    void OnCollisionEnter(Collision collision){
       if (collision.gameObject.tag == "Barrels")
      {
          GameObject tree = collision.gameObject;
          if (tree != null)
          {
          
              currentHealth -= 10f;
              Debug.Log("Health: " + currentHealth);
              update_healthbar();
           
          }
      }
    

    }

    [SerializeField]
    private Image Healthbar;
    public float maxhealth = 100f;
    public float currentHealth;

    private float Horizontal_input;
    private float Vertical_input;
    private float Brakes;
    private float Steer_Angle;
    public WheelCollider frontDriverW,
        frontPassengerW;
    public WheelCollider rearDriverW,
        rearPassengerW;
    public Transform frontDriverT,
        frontPassengerT;
    public Transform rearDriverT,
        rearPassengerT;
    public float maxSteerAngle = 35f;
    public float motorForce = 500f;
    private bool start;
   public AudioClip engineStartSound;
public AudioClip idle;
public AudioClip drive;
public AudioClip horn;

     private AudioSource engineStartAudioSource;
private AudioSource idleAudioSource;
private AudioSource driveAudioSource;
private AudioSource hornAudioSource;


    public float brakePower = 1000f;

    // public GameObject centerofMass;
    public Rigidbody carRigidbody;
}
