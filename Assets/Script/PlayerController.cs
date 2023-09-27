using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public AudioSource ripA;

    private float curentSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    [SerializeField] public bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Walk();
        Run();
        Jump();
    }

    public void Walk()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(x, 0, v).normalized;

        if (input != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(input, Vector3.up), Time.deltaTime * 10);
        }

        rb.velocity = input * curentSpeed + new Vector3(0, rb.velocity.y, 0);
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && isGround)
        {
            curentSpeed = speed * 1.5f;
        }
        else
        {
            curentSpeed = speed * 1;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            ripA.Play();
            StartCoroutine("Rip");
        }
    }

    IEnumerator Rip()
    {
        yield return new WaitForSeconds(3.4f);
        SceneManager.LoadScene(0);
    }
}