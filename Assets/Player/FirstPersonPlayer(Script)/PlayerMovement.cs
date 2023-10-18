using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Color color;
    Vector3 velocity;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<SphereCollider>().radius;
        TopCheckRadius = TopCheck.GetComponent<SphereCollider>().radius;
        realSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Walk();
        Run();
        SquatCheck();
        CheckingGround();
    }

    public Vector3 moveVector;
    public float moveSpeed = 10f;
    private float realSpeed;
    public float fastSpeed = 20f;
    void Walk()
    {
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;
        Vector3 moveInput = new Vector3(moveVector.x, 0, moveVector.z).normalized;

        controller.Move(move * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", Mathf.Abs(moveInput.magnitude));

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && isGround && !jumpLock)
        {
            realSpeed = fastSpeed;
            anim.SetBool("run", true);
        }
        else
        {
            realSpeed = moveSpeed;
            anim.SetBool("run", false);
        }
    }

    public float jumpHeight = 3f;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !jumpLock)
        {
            anim.StopPlayback();
            anim.Play("jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    private bool jumpLock;

    public float squatHeight = 0.6f;
    public float getUpHeight = 3.6f;

    public Vector3 squatPos = new Vector3(0, -1.2f, 0);
    public Vector3 getUpPos = new Vector3(0, 0, 0);

    void SquatCheck()
    {
        if (Input.GetKey(KeyCode.C) && isGround)
        {
            jumpLock = true;
            anim.SetBool("squat", true);
            controller.height = squatHeight;
            controller.center = squatPos;
        }
        else if (!Physics.CheckSphere(TopCheck.position, TopCheckRadius, Roof))
        {
            jumpLock = false;
            anim.SetBool("squat", false);
            controller.height = getUpHeight;
            controller.center = getUpPos;
        }
    }
    public bool isGround;
    public Transform GroundCheck;
    public LayerMask groundMask;
    private float GroundCheckRadius;

    void CheckingGround()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, groundMask);
        anim.SetBool("onGround", isGround);
    }
}
