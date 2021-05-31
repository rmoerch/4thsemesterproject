using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private float localCoolDownTime;
    private float shootCooldown;

    [SerializeField]
    private float bulletForce = 20f;

    private GameManager gM;

    private void Start()
    {
        gM = GameManager.instance;
        localCoolDownTime = gM.ShootCooldownTime;
        localCoolDownTime *= Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        //if (EventSystem.current.IsPointerOverGameObject()) return;

>>>>>>> Stashed changes
        if (shootCooldown <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                shootCooldown = localCoolDownTime;
            }
        }
        else if (shootCooldown > 0){ shootCooldown -= 1 * Time.deltaTime ; }
    }

    void Shoot()
    {
        //if heroAmmo.Shoot returns false - no ammo to shoot - don't shoot
        if (!gameObject.GetComponent<GunAmmo>().Shoot()) { return; }

        //Point 0 of bullet instantiation
        Vector3 position = (Vector3)gameObject.GetComponent<Rigidbody2D>().position;

        //An angle in deegrees to mouse cursor position
        Quaternion angle = new Quaternion();
        angle.eulerAngles = new Vector3(0f, 0f, gameObject.GetComponent<BlasterRotation>().shootAngle);

        //Instantiate a bullet, get rigidBody of the bullet and addForce in the mouse direction
        GameObject bullet = Instantiate(bulletPrefab, position, angle);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        //Vector3 firePoint is an Vector3 pointing in the direction of mouse cursor
        Vector3 firePoint = angle * Vector3.up;

        rb.AddForce( firePoint * bulletForce, ForceMode2D.Impulse);

    }
}
