using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{
    public float attackForce;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponentInParent<PlayerHP>().LoseHP(20);
            Vector3 a = new Vector3(10, 10, 10);
            collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(gameObject.GetComponentInParent<Rigidbody2D>().velocity.normalized * attackForce, ForceMode2D.Impulse);
        }
    }

}
