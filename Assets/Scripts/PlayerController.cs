using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float junpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int TakeOf = Animator.StringToHash("takeOf");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();
        if (moveInput == 0)
            anim.SetBool(IsRunning, false);
        else
            anim.SetBool(IsRunning, true);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        { 
            rb.velocity = Vector2.up * junpForce;
            anim.SetTrigger(TakeOf);
        }

        if (isGrounded == true)
            anim.SetBool(IsJumping, false);
        else
            anim.SetBool(IsJumping, true);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (moveInput < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if (moveInput > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
