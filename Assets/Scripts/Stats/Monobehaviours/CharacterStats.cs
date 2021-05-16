using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public CharacterStats_SO characterDefinition;
    public CharacterInventory charInv;
    public GameObject characterWeaponSlot;

    #region Constructors
    public CharacterStats()
    {
        charInv = CharacterInventory.instance;
    }


    #endregion

    #region Initializations
    private void Start()
    {
        if (!characterDefinition.setManually)
        {
            characterDefinition.maxHealth = 100;
            characterDefinition.currentHealth = 50;

            characterDefinition.currentGold = 15;

            characterDefinition.maxAmmo = 100;
            characterDefinition.currentAmmo = 50;

            characterDefinition.baseArmor = 5;
            characterDefinition.currentArmor = 5;

            characterDefinition.baseDamage = 10;
            characterDefinition.currentDamage = 10;

            characterDefinition.baseSpeed = 1;
            characterDefinition.currentSpeed = 1;
        }

    }
    #endregion


    #region Updates
    private void Update()
    {
        //2 is middle-mouse-button click
        //if (Input.GetMouseButtonDown(2))
        //{
        //    characterDefinition.saveCharacterData();
        //}
    }
    #endregion

    #region Stat Increasers
    public void ApplyHealth(int healthAmount)
    {
        characterDefinition.ApplyHealth(healthAmount);
    }

    public void ApplyGold(int goldAmount)
    {
        characterDefinition.ApplyGold(goldAmount);
    }

    public void ApplySpeed(int speedAmount)
    {
        characterDefinition.ApplySpeed(speedAmount);
    }

    public void ApplyDamage(int damageAmount)
    {
        characterDefinition.ApplyDamage(damageAmount);
    }

    public void ApplyArmor(int armorAmount)
    {
        characterDefinition.ApplyArmor(armorAmount);
    }
    #endregion

    #region Stat Reducers
    public void TakeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
    }

    public void SpendGold(int amount)
    {
        characterDefinition.SpendGold(amount);
    }

    public void UseAmmo(int amount)
    {
        characterDefinition.UseAmmo(amount);
    }

    public void ArmorDebuff(int amount)
    {
        characterDefinition.ArmorDebuff(amount);
    }

    public void SpeedDebuff(int amount)
    {
        characterDefinition.SpeedDebuff(amount);
    }
    #endregion

    #region Weapon and Armor Change

    public void ChangeWeapon(ItemPickUp weaponPickup)
    {
        if(!characterDefinition.UnEquipWeapon(weaponPickup, charInv, characterWeaponSlot))
        {
            characterDefinition.EquipWeapon(weaponPickup, charInv, characterWeaponSlot);
        }
    }
    #endregion

    #region Reporters

    public int GetHealth()
    {
        return characterDefinition.currentHealth;
    }
    
    public ItemPickUp GetCurrentWeapon()
    {
        return characterDefinition.weapon;
    }

    #endregion
}
