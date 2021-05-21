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

    private float hP;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;

        if(gM.currentHP <= 0)
        {
            hP = gM.maxHP;
        } else
        {
            hP = gM.currentHP;
        }
        
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

    private void FixedUpdate()
    {
        healthBar.SetHealth(hP);
        hitCooldown--;
        SaveData();
    }

    public void SaveData()
    {
        gM.currentHP = hP;
    }
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
