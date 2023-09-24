using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGround;

    private void Start()
    {
        realSpeed = moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        CheckingGround();
        SquatCheck();

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Walk();

        Jump();

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public Vector3 moveVector;
    public float moveSpeed = 12f;
    private float realSpeed;
    public float fastSpeed = 24f;

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;

        controller.Move(move * realSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    public void Run()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && isGround && !jumpLock)
        {
            realSpeed = fastSpeed;
        }
        else
        {
            realSpeed = moveSpeed;
        }
    }

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public void CheckingGround()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    private bool jumpLock;

    void SquatCheck()
    {
        if (Input.GetKeyDown(KeyCode.E) && isGround)
        {
            jumpLock = true;
            controller.height = 0.6f;
            controller.center = new Vector3(0f, -1.2f, 0f);
        }
        else if (!Physics.CheckSphere(TopCheck.position, TopCheckRadius, Roof))
        {
            jumpLock = false;
            controller.height = 3.6f;
            controller.center = new Vector3(0f, 0f, 0f);
           // controller.transform.position = new Vector3(0f, 0F, 0f);
        }
    }
}
