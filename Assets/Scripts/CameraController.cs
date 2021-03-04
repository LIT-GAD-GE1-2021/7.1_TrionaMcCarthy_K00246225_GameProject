using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform characterLocation;

    // Update is called once per frame
    void Update()
    {
        //set camera position = character position
        transform.localPosition = characterLocation.position + new Vector3(0,3,-15);
    }
}
