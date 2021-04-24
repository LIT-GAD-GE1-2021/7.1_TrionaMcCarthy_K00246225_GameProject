using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Rigidbody2D bullet;
    float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void FireRight()
    {
        bullet.AddForce(Vector2.right * 400);
        Vector3 scale = transform.localScale;
        scale.x = -0.6f;
        transform.localScale = scale;
    }
    public void FireLeft()
    {
        bullet.AddForce(Vector2.left * 400);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
