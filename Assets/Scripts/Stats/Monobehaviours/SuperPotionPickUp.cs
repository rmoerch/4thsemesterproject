using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPotionPickUp : MonoBehaviour
{
    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hero"))
        {
            gM.MaxHP += 100f;
            Destroy(gameObject);
        }
    }
}
