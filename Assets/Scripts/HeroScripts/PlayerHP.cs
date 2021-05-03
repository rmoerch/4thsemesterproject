using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    int maxHP = 100;
    [SerializeField]
    HealthBarScript healthBar;
    int hP;

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

    public void LoseHP(int damage)
    {
        if(hitCooldown <= 0)
        {
            hP -= damage;
            healthBar.SetHealth(hP);
            hitCooldown = hitCooldownTime;
        }
    }

    private void FixedUpdate()
    {
        if (hP <= 0) { Debug.Log("You died."); }
        hitCooldown--;
    }
}
