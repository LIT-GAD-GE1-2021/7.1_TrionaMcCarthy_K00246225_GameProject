using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCodeDump : MonoBehaviour
{
    /*This script exists only as an easy place for me to store pieces of code that I'm still
    working on, or that don't yet function as part of an existing script. It can effectively
    be ignored.

    void GroundCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 2f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    RaycastHit2D hit;
    hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, groundLayer);
    if(hit.collider !=null)

      void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            animator.SetBool("isGrounded", true);
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            animator.SetBool("isGrounded", false);
            isGrounded = false;
        }
    }



    */
}
