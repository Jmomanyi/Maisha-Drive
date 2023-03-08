using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackcarfollowcam : MonoBehaviour
{public Transform target;
    public Vector3 offset;

    void Start() {
        // Set the offset to be the difference between the camera's position and the car's position
        offset = transform.position - target.position;
    }

    void Update() {
        // Set the camera position to the target object's position, plus the offset
        transform.position = target.position + offset;

        // Set the camera orientation to look at the target object
        transform.LookAt(target);
    }
}
