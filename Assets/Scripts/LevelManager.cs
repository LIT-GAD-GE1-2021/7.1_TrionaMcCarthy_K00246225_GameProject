using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public LevelManager instance;
    public Text healthText;
    public int playerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth;
    }
}
