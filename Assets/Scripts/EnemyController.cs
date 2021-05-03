using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemy;
    RaycastHit2D hit;
    bool facingRight = false;
    bool playerDetected = false;
    float elapsedTime = 0;
    public float changeTime = 2;
    public LayerMask player;
    public int enemyHealth = 2;
    PolygonCollider2D enemyHitBox;
    Animator animator;

    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody2D>();
        enemyHitBox = gameObject.GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerDetect();
        if(enemyHealth > 0)
        {
            if (!playerDetected)
            {
                IdleMove();
            }
            else if (playerDetected)
            {
                Chase();
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 4)
            {
                Destroy(this.gameObject);
            }

        }

    }

    void PlayerDetect()
    {
        if(facingRight)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 5f, player);
        }
        else if(!facingRight)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 5f, player);
        }

        if(hit.collider != null)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    void IdleMove()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > changeTime * 2)
        {
            elapsedTime = 0;
        }
        else if (elapsedTime > changeTime)
        {
            enemy.velocity = new Vector2(2.5f, enemy.velocity.y);
            animator.SetBool("FacingRight", true);
            facingRight = true;
        }
        else if (elapsedTime > 0)
        {
            enemy.velocity = new Vector2(-2.5f, enemy.velocity.y);
            animator.SetBool("FacingRight", false);
            facingRight = false;
        }
    }

    void Chase()
    {
        if(facingRight)
        {
            enemy.velocity = new Vector2(4f, enemy.velocity.y);
        }
        else if(!facingRight)
        {
            enemy.velocity = new Vector2(-4f, enemy.velocity.y);
        }
    }

    public void HitSpell()
    {
        Debug.Log("spell hit enemy");
        enemyHealth = enemyHealth - LevelManager.instance.spellDamage;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }
       

    void Die()
    {
        animator.SetTrigger("Die");
        enemyHitBox.enabled = false;
    }
}
