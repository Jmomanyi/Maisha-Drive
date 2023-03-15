using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carmovement : MonoBehaviour
{
    public void getInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
      
        m_jump = Input.GetAxis("Jump");

    }

    public void update_healthbar()
    {
        Healthbar.fillAmount = currentHealth / maxhealth;
    }

    public void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }
//start
    public void StartEngine()
    {
         if (Input.GetKeyDown(KeyCode.E)){
        carsound.PlayIgnitionSound();
        m_engineOn = true;
         }
         else{
                m_engineOn = false;
         }
    }
    private void Accelerate()
    {
        if (m_engineOn==true)
        {
            carsound.PlayDrivingSound();
              frontDriverW.motorTorque = m_verticalInput * motorForce;
            frontPassengerW.motorTorque = m_verticalInput * motorForce;

        }
      
    }
//brke
    private void Brake()
    {
        if (m_jump>0)
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
        // carRigidbody.centerOfMass=centerofMass.transform.localPosition;
        currentHealth = maxhealth;
        update_healthbar();

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    

    void FixedUpdate()
    {
           if(Input.GetKeyDown(KeyCode.H)){
            carsound.PlayHornSound();
        }
        getInput();
        Steer();
        StartEngine();
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

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_jump;
    private bool m_engineOn=false;
    private float m_steeringAngle;
    public WheelCollider frontDriverW,
        frontPassengerW;
    public WheelCollider rearDriverW,
        rearPassengerW;
    public Transform frontDriverT,
        frontPassengerT;
    public Transform rearDriverT,
        rearPassengerT;
    public float maxSteerAngle = 30f;
    public float motorForce = 500f;

    public float brakePower = 1000f;

    // public GameObject centerofMass;
    public Rigidbody carRigidbody;

    public Carsound carsound;//sound
}
