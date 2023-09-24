using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;
    Vector3 velocity;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        realSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Walk();
        SquatCheck();
        CheckingGround();
    }

    public Vector3 moveVector;
    public float moveSpeed = 10f;
    private float realSpeed;
    public float fastSpeed = 20f;
    void Walk()
    {
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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

    public float jumpHeight = 3f;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !jumpLock)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    private bool jumpLock;

    void SquatCheck()
    {
        if (Input.GetKey(KeyCode.C) && isGround)
        {
            jumpLock = true;
            controller.height = 0.6f;
            controller.center = new Vector3(0, -1.2f, 0);
        }
        else if(!Physics.CheckSphere(TopCheck.position, TopCheckRadius, Roof))
        {
            jumpLock = false;
            controller.height = 3.6f;
            controller.center = new Vector3(0, 0, 0);
        }
    }
    public bool isGround;
    public Transform groundCheck;
    public LayerMask groundMask;
    private float groundDistane = 0.4f;

    void CheckingGround()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistane, groundMask);
    }
}
