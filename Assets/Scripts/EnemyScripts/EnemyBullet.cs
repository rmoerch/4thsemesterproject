using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletForce;

    private void Start()
    {
        //Igrone collision of bullets with bullets
        Physics2D.IgnoreLayerCollision(12, 12);
        Physics2D.IgnoreLayerCollision(9, 12);
        //Ignore collision of enemy bullets an enemy colliders
        Physics2D.IgnoreLayerCollision(12, 13);
        Physics2D.IgnoreLayerCollision(12, 11);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyHitBox")) { return; }
        if (collision.gameObject.CompareTag("EnemyBullet")) { return; }
        if (collision.gameObject.CompareTag("BossHitBox")) { return; }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponentInParent<PlayerHP>().LoseHP(20);
            collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(gameObject.transform.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
