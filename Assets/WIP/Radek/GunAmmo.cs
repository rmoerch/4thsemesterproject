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
    private int magazineSize;

    private int allAmmo;
    private int magazineAmmo;
    

    // Start is called before the first frame update
    void Start()
    {
        allAmmo = 62;
        magazineAmmo = magazineSize;

        updateUI();
    }

    public bool Shoot()
    {
        //If magazine ammo is empty
        if (magazineAmmo <= 0)
        {
            //if all ammo is out - can't reaload, can't shoot
            if(allAmmo <= 0) { return false; }
            //if ammo is left, then reload but don't shoot
            else { TryReloadGun(); return false; }
        }

        //If ammo still in magazine - allow to shoot and decreace magazine ammo
        else
        {
            magazineAmmo--;
            updateUI();
            return true;
        }
    }

    public void TryReloadGun()
    {
        //If magazine is full - don't reload
        if(magazineAmmo == magazineSize) { return; }

        else if(allAmmo <= 0) { return; }

        else
        {
            //Reload gun after 3 sec
            Invoke("ReloadGun", 3);
        }
    }

    private void ReloadGun()
    {
        //if allAmmo is equal to the magazine size, reload to full magazine
        if(allAmmo >= magazineSize) 
        { 
            magazineAmmo = magazineSize;
            allAmmo -= magazineSize;
            updateUI();
        }

        //if allAmmo is less the a magazine size, reload to all you can get
        else if(allAmmo < magazineSize)
        {
            magazineAmmo = allAmmo;
            allAmmo = 0;
            updateUI();
        }
    }

    private void updateUI()
    {
        magazineAmmoText.text = magazineAmmo.ToString();
        allAmmoText.text = allAmmo.ToString();
    }

}
