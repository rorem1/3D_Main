using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private float smoothInputSpeed = 10.0f;
    [SerializeField] private float jumpForce = 20.0f;

    
    private Rigidbody rb;
    private Animator anim;
    private CharacterController controller;

    private Vector3 smoothInput = Vector3.zero;
    
    
    private bool isGrounded = true;

    bool wDown;
         
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator> ();
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        

    }
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        Vector3 inputDir = new Vector3(h, 0.0f, v).normalized;


        smoothInput = Vector3.Lerp(smoothInput, inputDir, smoothInputSpeed * Time.deltaTime);

        if (smoothInput.sqrMagnitude > 0.1f)//거의0이 아니라면 = 이동중이라면
        {
            Quaternion targetRot = Quaternion.LookRotation(smoothInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }

        
        
        //transform.Translate(smoothInput * moveSpeed * Time.deltaTime, Space.World);
        if (wDown)
        {
            transform.position += inputDir * moveSpeed * 0.05f * Time.deltaTime;
        }
        else
        {
            transform.position += inputDir * moveSpeed * Time.deltaTime;
        }

        Vector3 move = smoothInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);

        //Vector3 move = smoothInput * moveSpeed * Time.deltaTime;
        //controller.Move(move);

        anim.SetBool("isRun", inputDir != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        
    }
    private void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        anim.SetBool("isJump", true);
        anim.SetTrigger("doJump");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJump", false);
            isGrounded = true;
        }
    }
}
