using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Text modeText;
    public Slider healthSlider;
    public int playerHealth = 5;
    public bool gameOver = false;
    public int characterMode = 1;
    public CharacterController character;

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
            modeText.text = "Mode: " + characterMode;
            healthSlider.value = playerHealth;
        }
        else if(playerHealth == 0)
        {
            healthSlider.value = 0;
            playerHealth = -1;
            gameOver = true;
            character.Die();
        }
    }
}
