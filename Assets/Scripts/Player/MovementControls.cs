using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    public static MovementControls Instance { get; private set; }

    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float gravity = 10.0f;

    [Header("Look Parameters")]
    private float lookSpeedX = 2.0f;
    private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;

    private float rotationX = 0;

    private Camera cam;
    private CharacterController cc;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private AudioSource aS;

    private bool paused
    { get { return GameManager.Instance.paused; } }

    public float lookSpeed
    {
        set 
        {
            lookSpeedX = value;
            lookSpeedY = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        cam = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!paused)
        {
            MoveInput();
            MouseInput();
            StepSound();
            MovePlayer();
        }
    }

    private bool isMoving
    {
        get { return Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0; } 
    }
    private void StepSound()
    {
        if (isMoving)
        {
            if (!aS.isPlaying)
            {
                if (aS.pitch > 0.5f) aS.pitch = 0.5f;
                else aS.pitch = 0.6f;

                aS.Play();
            }
        }
    }

    private void MoveInput()
    {
        currentInput = new Vector2(walkSpeed * Input.GetAxis("Vertical"), walkSpeed * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void MovePlayer()
    {
        if( !cc.isGrounded ) moveDirection.y -= gravity * Time.deltaTime;
        else moveDirection.y = 0;
        cc.Move(moveDirection * Time.deltaTime);
    }

    private void MouseInput()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

}