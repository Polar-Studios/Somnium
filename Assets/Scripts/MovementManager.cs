using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float horizontalMove;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private Boolean isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (!CanMove())
            return;

        horizontalMove = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 

        if(horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }


        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);


        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {

                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }

        bool CanMove()
        {
            bool can = true;

            if (DialogueManager.GetIstance().dialogueIsPlaying)
                can = false;
            if (FindObjectOfType<InventoryManager>().isOpen)
                can = false;
            if (FindObjectOfType<InputManager>().isPaused)
                can = false;

            return can; 
        }

    
    }
    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontalMove * speed, playerRb.velocity.y);
    }

   
}
