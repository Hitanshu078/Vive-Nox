using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fcam : MonoBehaviour
{    
    [SerializeField] float sensitivity = 2.0f; // Adjust this value to control rotation speed

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += mouseX * sensitivity;

        // Limit the vertical rotation between -90 and 90 degrees to prevent camera flipping
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation);
    }
}
