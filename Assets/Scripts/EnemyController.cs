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
    int enemyHealth = 2;
    PolygonCollider2D enemyHitBox;

    void Start()
    {
        enemy = gameObject.GetComponent<Rigidbody2D>();
        enemyHitBox = gameObject.GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        PlayerDetect();

        if (!playerDetected)
        {
            IdleMove();
        }
        else if(playerDetected)
        {
            Chase();
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
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            facingRight = true;
        }
        else if (elapsedTime > 0)
        {
            enemy.velocity = new Vector2(-2.5f, enemy.velocity.y);
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            enemyHealth = enemyHealth - LevelManager.instance.spellDamage;
            if (enemyHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        //death animation
        enemyHitBox.enabled = false;
    }
}
