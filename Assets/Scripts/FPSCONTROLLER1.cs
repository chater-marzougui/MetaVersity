using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 8f;
    public float SprintSpeed = 16f;
    public float JumpForce = 8f;
    public float LookSensitivity = 2f;
    public float Gravity = 20f;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float yaw = 0f;
    private float pitch = 0f;
    private float verticalVelocity = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Mouse Look
        yaw += Input.GetAxis("Mouse X") * LookSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * LookSensitivity;
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        moveDirection = move * ((Input.GetKey(KeyCode.LeftShift)) ? SprintSpeed : MoveSpeed);

        // Jump and Gravity
        if (characterController.isGrounded)
        {
            verticalVelocity = -Gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = JumpForce;
            }
        }
        else
        {
            verticalVelocity -= Gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;

        // Move the player
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
