using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Dados")]

    public int vida = 100;

	[Header("Movement")]
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float runSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 10.0f;
    [SerializeField] Transform playerBody;
    [SerializeField] private Camera playerCamera;

    private float mouseX;
    private float mouseY;
    private float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private Vector3 _forward;
    private Vector3 _right;

    private bool isRunning;

    private float curSpeedX;
    private float curSpeedY;

    private float movementDirectionY;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _forward = transform.TransformDirection(Vector3.forward);
        _right = transform.TransformDirection(Vector3.right);

        isRunning = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
        curSpeedX = canMove ? (isRunning ? runSpeed : moveSpeed) * Input.GetAxis("Vertical") : 0;
        curSpeedY = canMove ? (isRunning ? runSpeed : moveSpeed) * Input.GetAxis("Horizontal") : 0;
        movementDirectionY = moveDirection.y;
        moveDirection = (_forward * curSpeedX) + (_right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (canMove)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(moveDirection);
    }
}
