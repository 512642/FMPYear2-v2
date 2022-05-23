using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class PlayerMovement : MonoBehaviour
{
    public ClimbingProvider climbingProvider;
    [SerializeField] private InputActionReference jumpActionReference;
    public CharacterController characterController;
    public ActionBasedContinuousMoveProvider moveProvider;

    public bool saveGravity;
    public float gravity = -9.81f;
    public float jumpPower;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    public Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        saveGravity = true;
        jumpActionReference.action.performed += OnJump;

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        print("is grounded=" + isGrounded );



        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (saveGravity == false)
        {
            gravity = 0;
        }
        else
        {
            gravity = -9.81f;
        }

            velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
    private void OnJump(InputAction.CallbackContext obj)
    {
        if(isGrounded) 
        {
            velocity.y = jumpPower;
        }
    }
    
}
