using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    float maxHP = 100;
    [SerializeField]
    HealthBarScript healthBar;
    float hP;
    Spawner spawner;
    private GameObject deathMenu;
    public GameObject hero;

    //Cooldown for a hit - Player cannot be hit within hitCooldown time
    private int hitCooldown = 0;
    [SerializeField]
    private int hitCooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        hP = maxHP;
        healthBar.StartHealthBar(maxHP);
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
        hitCooldown--;
    }

    private void CheckIfGameOver()
    {
        if (hP <= 0)
        {
            //I guess we should call game manager to do its work at this point.
            //After death we save hero prefab, load GameOver scene
            //Inside GameOver scene, upon clicking PlayAgain, we pass saved hero prefab to spawner class

            //gameManager.SaveGame();
            SceneManager.LoadScene(3);
        }
        hitCooldown--;
    }
}
