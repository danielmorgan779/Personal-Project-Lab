using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovment : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    float xRotation = 0f;       
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        // cursor lock
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation around the x axis (Look up and down)
        xRotation -= mouseY;

        // Clamp the rotation
        xRotation = Mathf.Clamp(xRotation, 90f, 90f);

        // Rotation around the y axis (Look left and right)
        yRotation += mouseX;

        // Apply rotations to out transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}