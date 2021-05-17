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
    private Spawner sp;
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
            //GameManager.instance.heroPrefab = sp.GetHero();
            SceneManager.LoadScene(4);
        }
        hitCooldown--;
    }

}
