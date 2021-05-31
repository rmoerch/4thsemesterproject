using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletForce;

    private void Start()
    {
        //Igrone collision of bullets with bullets
        Physics2D.IgnoreLayerCollision(9, 9);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero")) { return; }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
        if(collision.gameObject.CompareTag("EnemyHitBox"))
        {
            collision.gameObject.GetComponentInParent<EnemyHP>().LoseHP(20);
            collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(gameObject.transform.up * bulletForce, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("BossHitBox"))
        {
            collision.gameObject.GetComponentInParent<BossHP>().LoseHP(20);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
