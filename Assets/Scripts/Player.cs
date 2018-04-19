using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float movementSpeed;
    private bool facingRight;
    private bool slide;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;
    }

    void Update()
    {
        HandleInput();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
        ResetValues();
    }

    private void HandleMovement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if (slide && !animator.GetCurrentAnimatorStateInfo(0).IsName("Kiko_Slide"))
        {
            animator.SetBool("slide", true);
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Kiko_Slide"))
        {
            animator.SetBool("slide", false);
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            slide = true;
        }
    }

    private void ResetValues()
    {
        slide = false;
    }
}
