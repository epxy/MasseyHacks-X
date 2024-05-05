using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove { get; private set; } = true;
    private bool isDashing => canDash && Input.GetKey(dashKey);

    [Header("Functional Options")]
    [SerializeField] private bool canDash = true;

    [Header("Controls")]
    [SerializeField] private KeyCode dashKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse1;

    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float dashSpeed = 6.0f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 100)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 100)] private float lowerLookLimit = 80.0f;

    [SerializeField] private Transform cameraRoot;
    [SerializeField] private Camera camera;
    private Rigidbody rb;

    [Header("Raycast Parameters")]
    [SerializeField] private float range = 10f;
    [SerializeField] private float wait = 1.0f;
    private float timer;

    private Vector3 moveDir;
    private Vector2 currentInput;

    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            HandleMovementInput();
            HandleMouseLook();
            ApplyFinalMovement();
            Extinguish();
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((isDashing? dashSpeed: moveSpeed) * Input.GetAxis("Vertical"), (isDashing ? dashSpeed : moveSpeed) * Input.GetAxis("Horizontal"));
    }

    private void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        cameraRoot.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void ApplyFinalMovement()
    {
        rb.velocity = cameraRoot.transform.forward * currentInput.x;
    }

    private void Extinguish()
    {
        RaycastHit hit;
        if(Input.GetButton("Fire1"))
        {
            Physics.Raycast(cameraRoot.transform.position, camera.transform.forward, out hit, range);
            if(hit.transform.gameObject.layer == 6)
            {
                if(timer <= wait)
                {
                    timer += Time.deltaTime;
                }
                if (timer > wait)
                {
                    hit.transform.GetComponent<fireSpawn>().Extinguish();
                    timer = 0.0f;
                }
            }
        }
    }
}
