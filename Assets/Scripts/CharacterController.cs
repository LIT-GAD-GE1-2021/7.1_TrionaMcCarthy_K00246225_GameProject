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
    bool facingRight = false;
    public GameObject spell;
    public Transform spellPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(LevelManager.instance.gameOver == false)
        {
            Walk();
            Jump();
            GroundCheck();
            vspeed = character.velocity.y;
            animator.SetFloat("vSpeed", vspeed);
            CharacterModeSwitch();
            Shoot();
        }
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
            facingRight = false;
        }

        if (Input.GetKey("right"))
        {
            character.velocity = new Vector2(7, character.velocity.y);
            Vector3 scale = transform.localScale;
            scale.x = -0.75f;
            transform.localScale = scale;
            animator.SetFloat("Speed", 3);
            facingRight = true;
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

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Hazard")
        {
            //animator.SetTrigger("Hurt");
            LevelManager.instance.playerHealth -= 0.1f;
        }
    }

    void CharacterModeSwitch()
    {
        if(Input.GetKeyDown("z"))
        {
            LevelManager.instance.characterMode += 1;
            if(LevelManager.instance.characterMode > 3)
            {
                LevelManager.instance.characterMode = 1;
            }
        }
    }

    public void Die()
    {
        Debug.Log("Game Over");
        //animator.SetTrigger("Death");
        //probably some other stuff idk yet
    }

    void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            if (facingRight == true)
            {
                GameObject spawnedSpell;
                spawnedSpell = Instantiate(spell, spellPosition.position + new Vector3(1, 2, 0), Quaternion.identity);
                SpellController script = spawnedSpell.GetComponent<SpellController>();
                script.FireRight();
            }
            else if (facingRight == false)
            {
                GameObject spawnedSpell;
                spawnedSpell = Instantiate(spell, spellPosition.position + new Vector3(-1, 2, 0), Quaternion.identity);
                SpellController script = spawnedSpell.GetComponent<SpellController>();
                script.FireLeft();
            }

        }
    }
}
