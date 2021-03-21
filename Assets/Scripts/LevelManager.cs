using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Text healthText;
    public Slider healthSlider;
    public int playerHealth = 5;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        instance = this;
        playerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth > 0)
        {
            healthText.text = "Health: " + playerHealth;
            healthSlider.value = playerHealth;
        }
        else if(playerHealth == 0)
        {
            healthText.text = "Game Over";
            healthSlider.value = 0;
            gameOver = true;
        }
    }
}
