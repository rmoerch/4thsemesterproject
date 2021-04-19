using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrackeyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //Vector2 mousePos;
    //Camera cam;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } 
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 lookDir = mousePos - rb.position;
        //Vector2 normLookDir = Vector2.ClampMagnitude(lookDir, 1);

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }
}
