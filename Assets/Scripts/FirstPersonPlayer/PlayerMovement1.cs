using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -9.8f;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        GroundCheckRadius = GroundCheck.GetComponent<SphereCollider>().radius;
        TopCheckRadius = TopCheck.GetComponent<SphereCollider>().radius;
        realSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Run();
        Jump();
        SquatCheck();
        CheckGround();
    }

    public Vector3 moveVector;
    public float speed = 10f;
    private float realSpeed;
    public float fastSpeed = 20f;
    void Walk()
    {
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;
        controller.Move(move * realSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public float jumpHeight = 3;
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGround && !jumpLock)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
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
            realSpeed = speed;
        }
    }

    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    private bool jumpLock;

    void SquatCheck()
    {
        if ((Input.GetKey(KeyCode.C) && isGround))
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
        }
    }
    public bool isGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    void CheckGround()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, Ground);
    }
}
