using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        realSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Run();
        Jump();
        CheckGround();
        SquatCheck();

    }

    public Vector3 moveVector;
    public float moveSpeed; 
    public void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(moveVector.x, 0, moveVector.z).normalized;

        if (moveInput != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveInput, Vector3.up), Time.deltaTime * 10);
        }

        rb.velocity = moveInput * realSpeed + new Vector3(0, rb.velocity.y, 0);
        anim.SetFloat("Speed", Mathf.Abs(moveInput.magnitude));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveVector.x * realSpeed, rb.velocity.y, moveVector.z * realSpeed);
    }

    public float jumpForce = 210f;
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround && !jumpLock)
        {
            anim.StopPlayback();
            anim.Play("jump");
            rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z));
        }
    }

    public float fastSpeed = 6f;
    public float realSpeed;
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

    public bool isGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;
    void CheckGround()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, Ground);
        anim.SetBool("onGround", isGround);
    }

    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    public Collider posStand;
    public Collider posSquat;
    private bool jumpLock;

    void SquatCheck()
    {
        if ((Input.GetKey(KeyCode.C) && isGround))
        {
            anim.SetBool("squat", true);
            posStand.enabled = false;
            posSquat.enabled = true;
            jumpLock = true;
        }
        else if (!Physics.CheckSphere(TopCheck.position, TopCheckRadius, Roof))
        {
            anim.SetBool("squat", false);
            posStand.enabled = true;
            posSquat.enabled = false;
            jumpLock = false;
        }
    }
}
