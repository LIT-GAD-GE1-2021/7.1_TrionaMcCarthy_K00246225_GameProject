using System.Collections;
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

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        GroundCheck();
        vspeed = character.velocity.y;
        animator.SetFloat("vSpeed", vspeed);
        animator.SetBool("isGrounded", isGrounded);
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
        if (Input.GetKeyDown("up") && isGrounded)
        {
            animator.SetTrigger("Jump");
            character.velocity = new Vector2(character.velocity.x, 17);
            //isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //if(collider.gameObject.tag = "Ground")
        {
            //animator.SetBool("isGrounded", true);
            //isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        //if(collider.gameObject.tag = "Ground")
        {
            //animator.SetBool("isGrounded", false);
            //isGrounded = false;
        }
    }

    void GroundCheck()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 2f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
