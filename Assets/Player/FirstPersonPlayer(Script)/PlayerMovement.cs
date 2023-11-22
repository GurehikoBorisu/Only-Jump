using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Camera cam;

    Vector3 velocity;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        realSpeed = moveSpeed;
        cam = FindObjectOfType<Camera>();
        transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
        Debug.Log($"{PlayerPrefs.GetFloat("posX")},{PlayerPrefs.GetFloat("posY")},{PlayerPrefs.GetFloat("posZ")}");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        velocity.y += gravity * Time.deltaTime;
    }
    void Update()
    {
        if (!isRotating)
        {
            Jump();
        }
        //Jump();
        Walk();
        Run();
        SquatCheck();
        CheckingGround();
        ChangeGravity();
    }

    [Header("Move")]
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

        if(moveVector != Vector3.zero && !footstepSound.isPlaying && isGround)
        {
            PlayFootStepSound();
        }

        controller.Move(move * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", Mathf.Abs(moveInput.magnitude));

        //if (!isRotating)
        //{
        //    velocity.y += gravity * Time.deltaTime;
        //}
        controller.Move(velocity * Time.deltaTime);
    }

    [Header("Audio")]

    public AudioSource footstepSound;
    public AudioClip[] footstepSounds;
    private void PlayFootStepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            AudioClip randomClip = footstepSounds[randomIndex];
            footstepSound.clip = randomClip;

            footstepSound.Play();
        }
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

    [Header("Jump")]
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

    [Header("SquatCheck")]
    public Transform TopCheck;
    public float TopCheckRadius;
    public LayerMask Roof;
    private bool jumpLock;

    public float squatHeight = 0.6f;
    public float getUpHeight = 3.6f;

    public Vector3 squatPos = new Vector3(0, -1.2f, 0);
    public Vector3 getUpPos = new Vector3(0, 0, 0);

    public float cameraSquatPosY = -0.1f;
    public float cameragetUpPosY = 0.2f;
    void SquatCheck()
    {
        if (Input.GetKey(KeyCode.C) && isGround)
        {
            jumpLock = true;
            anim.SetBool("squat", true);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y + cameraSquatPosY, transform.position.z); ;
            controller.height = squatHeight;
            controller.center = squatPos;
        }
        else if (!Physics.CheckSphere(TopCheck.position, TopCheckRadius, Roof))
        {
            jumpLock = false;
            anim.SetBool("squat", false);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y + cameragetUpPosY, transform.position.z);
            controller.height = getUpHeight;
            controller.center = getUpPos;
        }
    }

    [Header("CheckingGround")]
    public bool isGround;
    public Transform GroundCheck;
    public LayerMask groundMask;
    public float GroundCheckRadius;

    void CheckingGround()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, groundMask);
        anim.SetBool("onGround", isGround);
    }

    [Header("ChangeGravity")]
    public bool isRotating = true;

    public void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.G) && isGround && !jumpLock) 
        {
            if (isRotating)
            {
                //isRotating = false;
                gravity = (gravity == 9.8f) ? -9.8f : 9.8f;
                velocity.y = 0;
                //StartCoroutine(ChangeGravityAndRotateObject());
                StartCoroutine("ChangeGravityAndRotateObject");
            }
        }
    }

    private System.Collections.IEnumerator ChangeGravityAndRotateObject()
    {
        //gravity = (gravity == 9.8f) ? -9.8f : 9.8f;

        //velocity.y += gravity * Time.deltaTime;

        Physics.gravity = new Vector3(0, gravity, 0);

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 180f);
        //Quaternion targetRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 180f);

        float startTime = Time.time;
        //float duration = 1.0f;
        float duration = 0.35f;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (GroundCheck == null)
            return;
        if (TopCheck == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(TopCheck.position, TopCheckRadius);
    }
}
