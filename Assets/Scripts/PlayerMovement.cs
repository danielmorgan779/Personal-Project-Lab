using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 veloctiy;

    bool isGrounded;
    //bool isMoving; 

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Resets the default velocity
        if(isGrounded && veloctiy.y < 0)
        {
            veloctiy.y = -2f;
        }


        // getting the inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Creating the moving vector
        Vector3 move = transform.right * x + transform.forward * z; //(right - red axis, forward - blue axis)

        // Actually moving the player
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Going up
            veloctiy.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling down
        veloctiy.y += gravity * Time.deltaTime;

        // Executing the jump
        controller.Move(veloctiy * Time.deltaTime);

        /*if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            // for later use
        }
        else
        {
            isMoving = false;
            // for later use
        }*/

        lastPosition = gameObject.transform.position;
    }
}
