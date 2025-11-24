using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour

{

    public Camera playerCamera;

    public float walkSpeed = 20f;

    public float runSpeed = 20f;

    public float jumpPower = 2f;

    public float gravity = -10f;

    public float lookSpeed = 2f;

    public float lookXLimit = 45f;

    public float defaultHeight = 2f;

    public float crouchHeight = 1f;

    public float crouchSpeed = 3f;



    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 0;

    private CharacterController characterController;

    private Rigidbody _rb;



    private bool canMove = true;



    void Start()

    {

        _rb = GetComponent<Rigidbody>();

        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

    }



    void Update()

    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        Vector3 right = transform.TransformDirection(Vector3.right);



        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 5;

        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 5;
            

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);



        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)

        {

            moveDirection.y = jumpPower;

        }

        else

        {

            moveDirection.y = movementDirectionY;

        }



        if (!characterController.isGrounded)

        {

            moveDirection.y -= gravity * Time.deltaTime;

        }



        if (Input.GetKey(KeyCode.R) && canMove)

        {

            characterController.height = crouchHeight;

            walkSpeed = crouchSpeed;

            runSpeed = crouchSpeed;



        }

        else

        {

            characterController.height = defaultHeight;

            walkSpeed = 20f;

            runSpeed = 20f;

        }



        characterController.Move(moveDirection * Time.deltaTime);



        if (canMove)

        {

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;

            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        }

    }

}
