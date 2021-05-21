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
    [SerializeField]

    private int allAmmo;
    private int localMagAmmo;

    private bool isReloading;

    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;
        allAmmo = gM.allAmmo;
        localMagAmmo = gM.magAmmo;

        if(localMagAmmo == 0)
        {
            localMagAmmo = gM.magSize;
            allAmmo -= localMagAmmo;  
        } else
        {
            //allAmmo -= localMagAmmo;
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
            //if ammo is left, then reload but don't shoot
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
        if(localMagAmmo == gM.magSize) { return; }
        //If already reloading - don't reload
        if(isReloading) { return; }

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
        //if allAmmo is equal to the magazine size, reload to full magazine
        if(allAmmo >= gM.magSize) 
        { 
            localMagAmmo = gM.magSize;
            allAmmo -= localMagAmmo;
            updateUI();
        }

        //if allAmmo is less the a magazine size, reload to all you can get
        else if(allAmmo < gM.magSize)
        {
            localMagAmmo = allAmmo;
            allAmmo = 0;
            updateUI();
        }
        isReloading = false;
    }

    private void updateUI()
    {
        SaveData();
        magazineAmmoText.text = localMagAmmo.ToString();
        allAmmoText.text = allAmmo.ToString();
    }

    private void SaveData()
    {
        gM.allAmmo = allAmmo;
        gM.magAmmo = localMagAmmo;
    }

    private void FixedUpdate()
    {
        SaveData();
    }
}
