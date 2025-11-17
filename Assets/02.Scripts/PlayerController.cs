using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;

    private Animator anim;
    private Rigidbody rb;

    float h;
    float v;
    bool isRunning;
    Vector3 dir;


    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();

        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //anim.SetBool("Jump2", true);
            //anim.SetTrigger("Jump");
            Jump();
        }

        anim.SetBool("Walk", dir != Vector3.zero);

        anim.SetBool("Run", isRunning);

        //anim.SetTrigger("Jump");

        

        transform.LookAt(transform.position + dir);
        //Quaternion targetRotation = Quaternion.LookRotation(dir);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
        
    }
    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, 0.0f, v).normalized;

        //if(dir.magnitude > 0.1f)
        //{
        //    Quaternion playerRot = Quaternion.LookRotation(dir);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, Time.deltaTime * 100f);
        //}

        rb.MovePosition(rb.position + dir * moveSpeed * (isRunning ? 3f : 1f) * Time.deltaTime);
        //transform.position += dir*moveSpeed *(isRunning?3f:1f)* Time.deltaTime;
    }
    private void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(rb.velocity.x , 0f ,  rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //anim.SetBool("Jump2", false);
        }
    }

}
