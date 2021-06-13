using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAmmo : MonoBehaviour
{
    [SerializeField]
    private Text allAmmoText;
    [SerializeField]
    private Text magazineAmmoText;

    private int allAmmo;

    private int localMagAmmo;

    private int ammoRestore;

    private bool isReloading;

    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;

        //Take values from game manager 
        allAmmo = gM.AllAmmo;
        localMagAmmo = gM.MagAmmo;
        ammoRestore = gM.AmmoRestore;

        //if it is first run, magazine is going to be empty
        if (localMagAmmo == 0)
        {
            //fill magazine with ammo from all ammo
            localMagAmmo = gM.MagSize;
            allAmmo -= localMagAmmo;
        }
        else
        {
            //if magazine ammo is not empty, it is not the first run and value of magazine is already available in game manager
            //Do nothing
        }

        updateUI();
    }

    public bool Shoot()
    {
        //If magazine ammo is empty
        if (localMagAmmo <= 0)
        {
            //if all ammo is out - can't reaload, can't shoot
            if(allAmmo <= 0) { return false; }

            //if ammo is left, then try to reload the gun
            else { TryReloadGun(); return false; }
        }

        //If ammo still in magazine - allow to shoot and decreace magazine ammo
        else
        {
            localMagAmmo--;
            updateUI();
            return true;
        }
    }

    public void TryReloadGun()
    {
        //If magazine is full - don't reload
        if(localMagAmmo == gM.MagSize) { return; }

        //If already reloading - don't reload
        if(isReloading) { return; }

        //If player is out of ammo, dont do anything
        else if(allAmmo <= 0) { return; }

        else
        {
            isReloading = true;
            //Reload gun after 3 sec
            Invoke("ReloadGun", 3);
        }
    }

    private void ReloadGun()
    {
        //if allAmmo is more than magazine size or equal, reload to full magazine and distract value from allammo
        if(allAmmo >= gM.MagSize) 
        { 
            localMagAmmo = gM.MagSize;
            allAmmo -= localMagAmmo;
            updateUI();
        }

        //if allAmmo is less the a magazine size, reload to all you can get
        else if(allAmmo < gM.MagSize)
        {
            localMagAmmo = allAmmo;
            allAmmo = 0;
            updateUI();
        }
        isReloading = false;
    }

    public void AmmoRestore()
    {
        allAmmo += ammoRestore;
        updateUI();
    }

    //update ammo texts in the bottom, but also pass values to game manager
    private void updateUI()
    {
        SaveData();
        magazineAmmoText.text = localMagAmmo.ToString();
        allAmmoText.text = allAmmo.ToString();
    }

    //update all ammo and currently loaded magazine to game manager
    private void SaveData()
    {
        gM.AllAmmo = allAmmo;
        gM.MagAmmo = localMagAmmo;
        
    }

    //send data to game manager each fixed frame
    private void FixedUpdate()
    {
        SaveData();
    }
}
