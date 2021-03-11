﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D character;
    public bool isGrounded = false;
    public float vspeed;
    public LayerMask groundLayer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Jump();
        GroundCheck();
        vspeed = character.velocity.y;
        animator.SetFloat("vSpeed", vspeed);
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
    }

    void Walk()
    {
        if (Input.GetKey("left"))
        {
            character.velocity = new Vector2(-7, character.velocity.y);
            Vector3 scale = transform.localScale;
            scale.x = 0.75f;
            transform.localScale = scale;
            animator.SetFloat("Speed", 3);
        }

        if (Input.GetKey("right"))
        {
            character.velocity = new Vector2(7, character.velocity.y);
            Vector3 scale = transform.localScale;
            scale.x = -0.75f;
            transform.localScale = scale;
            animator.SetFloat("Speed", 3);
        }

        if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))
        {
            animator.SetFloat("Speed", 0);
            character.velocity = new Vector2(0, character.velocity.y);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("up") && isGrounded || Input.GetKeyDown("c") && isGrounded)
        {
            animator.SetTrigger("Jump");
            character.velocity = new Vector2(character.velocity.x, 19);
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    RaycastHit2D hit;
    void GroundCheck()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

}
