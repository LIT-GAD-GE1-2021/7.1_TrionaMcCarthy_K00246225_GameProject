using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float playerHealth = 1;
    public bool gameOver = false;
    public int characterMode = 1;
    public CharacterController character;
    public Image healthBar;
    public GameObject WitchIcon;
    public GameObject SoldierIcon;
    public GameObject NinjaIcon;
    public int KeyCount = 0;
    public GameObject KeyUI;
    public int spellDamage = 1;
    public GameObject PowerUpUI;

    void Start()
    {
        gameOver = false;
        instance = this;
        playerHealth = 1;
    }

    void Update()
    {
        if(playerHealth > 0)
        {
            healthBar.fillAmount = playerHealth;
            if(characterMode == 1)
            {
                WitchIcon.SetActive(true);
                SoldierIcon.SetActive(false);
                NinjaIcon.SetActive(false);
            }
            else if(characterMode == 2)
            {
                WitchIcon.SetActive(false);
                SoldierIcon.SetActive(true);
                NinjaIcon.SetActive(false);
            }
            else if(characterMode == 3)
            {
                WitchIcon.SetActive(false);
                SoldierIcon.SetActive(false);
                NinjaIcon.SetActive(true);
            }
        }
        else if(playerHealth <= 0 && !gameOver)
        {
            healthBar.fillAmount = 0;
            character.Die();
            gameOver = true;
        }
    }

    public void KeyCollect()
    {
        KeyCount++;
        if(KeyCount>0)
        {
            KeyUI.SetActive(true);
        }
    }

    public void KeyUse()
    {
        if(KeyCount > 0)
        {
            KeyCount--;
            if (KeyCount <= 0)
            {
                KeyUI.SetActive(false);
            }
        }
        
    }

    public void PowerUp()
    {
        spellDamage++;
        Debug.Log("Collected Powerup!");
        PowerUpUI.SetActive(true);
    }
}
