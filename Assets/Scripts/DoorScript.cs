using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    BoxCollider2D doorHitBox;
    CircleCollider2D doorTriggerBox;
    Animator animator;

    void Start()
    {
        doorHitBox = gameObject.GetComponent<BoxCollider2D>();
        doorTriggerBox = gameObject.GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if(LevelManager.instance.KeyCount > 0)
            {
                doorHitBox.enabled = false;
                doorTriggerBox.enabled = false;
                animator.enabled = true;
                LevelManager.instance.KeyUse();
            }
        }
    }

}
