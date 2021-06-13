using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private float localCoolDownTime;
    private float shootCooldown;

    [SerializeField]
    private float bulletForce = 20f;

    private GameManager gM;
    private AudioSource _audioSource;

    private void Start()
    {
        gM = GameManager.instance;
        _audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (EventSystem.current.IsPointerOverGameObject()) return;

        if (shootCooldown <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                _audioSource.Play();
                Shoot();
                shootCooldown = gM.ShootCooldownTime;
            }
        }
        else if (shootCooldown > 0){ shootCooldown -= 1; }
    }

    void Shoot()
    {
        //if heroAmmo.Shoot returns false - no ammo to shoot - don't shoot
        if (!gameObject.GetComponent<GunAmmo>().Shoot()) 
        {
            _audioSource.Stop();
            return; 
        }

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
