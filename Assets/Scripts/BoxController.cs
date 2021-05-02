using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    Rigidbody2D box;

    void Start()
    {
        box = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(LevelManager.instance.characterMode == 2)
        {
            box.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            box.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
