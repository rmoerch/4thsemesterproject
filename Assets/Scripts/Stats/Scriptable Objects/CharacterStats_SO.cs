using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    #region Fields
    
    public bool setManually = false;
    public bool saveDataOnClose = false;

    public ItemPickUp gold { get; private set; }
    public ItemPickUp healthPotion { get; private set; }
    public ItemPickUp weapon { get; private set; }
    public ItemPickUp misc1 { get; private set; }


    public int maxHealth = 0;
    public int currentHealth = 0;

    //public int maxGold = 0;
    public int currentGold = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public int baseArmor = 0;
    public int currentArmor = 0;

    public int baseSpeed = 0;
    public int currentSpeed = 0;


    #endregion

    #region Stat Increasers

    public void ApplyHealth(int healthAmount)
    {
        if((currentHealth + healthAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void ApplyGold(int goldAmount)
    {
        currentGold += goldAmount;
    }

    public void ApplyDamage(int damageAmount)
    {
        currentDamage += damageAmount;
    }

    public void ApplyArmor(int armorAmount)
    {
        currentArmor += armorAmount;
    }

    public void ApplySpeed(int speedAmount)
    {
        currentSpeed += speedAmount;
    }

    #endregion

    #region Stat Reducers

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            //Death();
        }
    }

    public void SpendGold(int amount)
    {
        currentGold -= amount;
    }

    public void ArmorDebuff(int amount)
    {
        currentArmor -= amount;
    }

    public void SpeedDebuff(int amount)
    {
        currentSpeed -= amount;
    }
    #endregion

    #region Character Death

    private void Death()
    {
        Debug.Log("You've died!");
        //Death state and trigger respawn
    }

    #endregion
}
