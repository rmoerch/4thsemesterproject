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
        deathMenu = transform.Find("/Canvas/DeathMenu").gameObject;
        deathMenu.SetActive(false);
        hP = maxHP;
        healthBar.StartHealthBar(maxHP);
    }

    public void LoseHP(float damage)
    {
        if(hitCooldown <= 0)
        {
            hP -= damage;
            Debug.Log(hP);
            healthBar.SetHealth(hP);
            hitCooldown = hitCooldownTime;
            CheckIfGameOver();
        }
    }

    private void FixedUpdate()
    {
        hitCooldown--;
    }
    private void Restart()
    {
        Debug.Log("lesss go");
        //Load the last scene loaded, in this case Main, the only scene in the game.
        //deathMenu = GameObject.Find("/Canvas/DeathMenu");
        Debug.Log(deathMenu);
        deathMenu.SetActive(true);
        enabled = false;
    }
    private void CheckIfGameOver()
    {
        if (hP <= 0)
        {
            //Debug.Log("You died.");

            //try
            //{
            //    hero = spawner.heroClone;
            //    DontDestroyOnLoad(hero);
            //} catch
            //{
            //    Debug.Log(hero);
            //}
            Invoke("Restart", 1f);
        }
        hitCooldown--;
    }
}
