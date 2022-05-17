using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 50.0f;
    public CharacterController characterController;


    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        jumpActionReference.action.performed += OnJump;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (!characterController)
            characterController = GetComponent<CharacterController>();

    }
    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!isGrounded) return;
        characterController.Move(Vector3.up * jumpForce);
        print("jumping");
    }



}
