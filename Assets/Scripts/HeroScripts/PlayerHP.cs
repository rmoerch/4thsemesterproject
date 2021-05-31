using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    private GameManager gM;

    [SerializeField]
    HealthBarScript healthBar;

    //Cooldown for a hit - Player cannot be hit within hitCooldown time
    private int hitCooldown = 0;

    //hold value for how much it should wait in cooldown, must be declared in Unity inspector
    [SerializeField]
    private int hitCooldownTime;

    //local value of player hp
    private float hP;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;

        
        if(gM.currentHP <= 0)
        {
            //if hp value in game manager value is <=0, it means the game is started for a first time or player has died
            hP = gM.maxHP;
        } else
        {
            //if current hp is not <=0, means character is alive, which in ints turn means it has switched playable scenes
            hP = gM.currentHP;
        }
        
        //Initialize health bar with maximum value and local value of current hp
        healthBar.StartHealthBar(gM.maxHP, hP); 
    }


    public void GetHP(float health)
    {
        if (hP < 100)
        {
            hP += health;
            healthBar.SetHealth(hP);
        }
        
    }

    public void LoseHP(float damage)
    {
        if(hitCooldown <= 0)
        {
            hP -= damage;
            healthBar.SetHealth(hP);
            hitCooldown = hitCooldownTime;
            CheckIfGameOver();
        }
    }

    //update health bar, update hit cool down and save data each fixed frame of the game
    private void FixedUpdate()
    {
        healthBar.SetHealth(hP);
        hitCooldown--;
        SaveData();
    }

    //pass local hp value to global game manager instance
    public void SaveData()
    {
        gM.currentHP = hP;
    }

    //If player dies
    private void CheckIfGameOver()
    {
        if (hP <= 0)
        {
            SaveData();
            //If hp is 0 or less, character dies and game loads GameOver scene
            //Load game over scene, hard coded value
            //18 may, game over scene is number 4 in build settings
            SceneManager.LoadScene(4);
        }
        hitCooldown--;
    }

}
