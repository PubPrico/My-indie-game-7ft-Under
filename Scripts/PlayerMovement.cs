using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public AudioSource audi;
    [Header("Movement")]
    float speed;
    public float walkSpeed, sprintSpeed;
    public float groundDrag;
    bool staminaCD;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCD;
    public  float airMultiplier;
    bool readyToJump;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded;

    public Transform orientation;

    float horizontalInput, verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    public MoveState state;

    public enum MoveState
    {
        walking,
        sprinting,
        air
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        staminaCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        PlayerInput();
        SpeedControl();
        StateHandler();

        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    void FixedUpdate()
    {
        MovePLayer();
    }

    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && readyToJump && isGrounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCD);
        }
    }

    void StateHandler()
    {
        if(PlayerStat.currentStamina <= 0)
        {
            staminaCD = true;
            
        }
        else if(PlayerStat.currentStamina >= 50)
        {
            staminaCD = false;
        }

        if(isGrounded && Input.GetKey(KeyCode.LeftShift) && PlayerStat.currentStamina > 0 && !staminaCD)
        {
            state = MoveState.sprinting;
            speed = sprintSpeed;
        }
        else if(isGrounded)
        {
            state = MoveState.walking;
            speed = walkSpeed;
        }
        else
        {
            state = MoveState.air;
        }
    }

    void MovePLayer()
    {
        //Movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //On ground
        if(isGrounded)
        {
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }
        //In air
        else if(!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * speed * airMultiplier, ForceMode.Force);
        }

        
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        if(flatVel.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            audi.enabled = true;
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsSprinting", true);
        }
        else if(flatVel.magnitude > 0)
        {
            audi.enabled = false;
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsSprinting", false);
        }
        if(flatVel.magnitude <= 0)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsSprinting", false);
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }
    
}
