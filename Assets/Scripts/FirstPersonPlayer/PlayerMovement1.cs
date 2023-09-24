using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;
<<<<<<< HEAD

    public float gravity = -9.8f;
    Vector3 velocity;

=======
    Vector3 velocity;
    public float gravity;
>>>>>>> parent of 59de4f1 (Revert "PlayerController")
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
<<<<<<< HEAD
        GroundCheckRadius = GroundCheck.GetComponent<SphereCollider>().radius;
        TopCheckRadius = TopCheck.GetComponent<SphereCollider>().radius;
        realSpeed = speed;
=======
        realSpeed = moveSpeed;
>>>>>>> parent of 59de4f1 (Revert "PlayerController")
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Walk();
        Run();
        Jump();
        SquatCheck();
        CheckGround();
    }

    public Vector3 moveVector;
    public float speed = 10f;
=======
        Jump();
        Walk();
        SquatCheck();
        CheckingGround();
    }

    public Vector3 moveVector;
    public float moveSpeed = 10f;
>>>>>>> parent of 59de4f1 (Revert "PlayerController")
    private float realSpeed;
    public float fastSpeed = 20f;
    void Walk()
    {
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
<<<<<<< HEAD
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;
        controller.Move(move * realSpeed * Time.deltaTime);
=======
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;
        controller.Move(move * moveSpeed * Time.deltaTime);

>>>>>>> parent of 59de4f1 (Revert "PlayerController")
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

<<<<<<< HEAD
    public float jumpHeight = 3;
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGround && !jumpLock)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

=======
>>>>>>> parent of 59de4f1 (Revert "PlayerController")
    public void Run()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && isGround && !jumpLock)
        {
            realSpeed = fastSpeed;
        }
        else
        {
<<<<<<< HEAD
            realSpeed = speed;
=======
            realSpeed = moveSpeed;
        }
    }

    public float jumpHeight = 3f;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !jumpLock)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
>>>>>>> parent of 59de4f1 (Revert "PlayerController")
        }
    }

    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    private bool jumpLock;

    void SquatCheck()
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> parent of 59de4f1 (Revert "PlayerController")
    }
}
