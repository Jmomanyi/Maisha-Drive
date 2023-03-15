using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  using TMPro;

public class speedometer : MonoBehaviour
{
     public Transform car;
    public TextMeshProUGUI speedText;

    private Vector3 lastPosition;
    private float speed;

    private void FixedUpdate()
    {
        // Calculate the distance the car has moved since the last frame
        float distance = Vector3.Distance(car.position, lastPosition);

        // Calculate the speed based on the distance and the time elapsed since the last frame
        speed = distance / Time.fixedDeltaTime;

        // Update the last position to the current position
        lastPosition = car.position;

        // Update the speed text
        speedText.text = "Speed: " + Mathf.RoundToInt(speed * 3.6f) + " km/h";
    }
  
}
