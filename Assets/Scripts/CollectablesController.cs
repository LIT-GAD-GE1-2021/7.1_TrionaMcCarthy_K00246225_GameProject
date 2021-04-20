using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "Key")
            {
                LevelManager.instance.KeyCollect();
            }
            else if(this.gameObject.tag == "Collectable")
            {
                //do something else
                Debug.Log("Collected Thing");
            }

            Destroy(this.gameObject);
        }
    }
}
