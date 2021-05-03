using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletForce;

    private void Start()
    {
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
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
