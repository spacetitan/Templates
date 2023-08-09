using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMotor playerMotor{get; private set;} = null;
    public PlayerCamera playerCamera{get; private set;} = null;

    public Transform playerTransform{get; private set;} = null;
    public CharacterController playerCharCon = null;
    public CapsuleCollider playerCollider = null;
    public LayerMask groundLayer = new LayerMask();

    public Transform rotatePoint = null;
    public Transform groundCheck = null;
    public CameraType cameraType = CameraType.THIRDPERSON; //add CameraTypeEnum
     
    public bool isGrounded = false;
    public bool isMoving = false;

    void Awake()
    {
        this.playerTransform = this.gameObject.transform;

        if(!this.gameObject.GetComponent<CharacterController>())
        {
            this.playerCharCon = this.gameObject.AddComponent<CharacterController>();
        }

        if(!this.gameObject.GetComponent<CapsuleCollider>())
        {
            this.playerCollider = this.gameObject.AddComponent<CapsuleCollider>();
        }

        this.groundLayer = LayerMask.GetMask("Environment"); //Add layer

        this.playerMotor = new PlayerMotor(this);
        this.playerCamera = new PlayerCamera(this);
    }
    void Start()
    {
        this.playerCamera.InitializeCamera();
    }

    void Update()
    {
        this.isGrounded = GroundCheck();

        this.playerMotor.Movement();
        this.playerCamera.Rotation();
    }

    private bool GroundCheck()
    {
        return Physics.CheckSphere(this.groundCheck.position, this.playerCollider.radius, this.groundLayer);
    }
}
