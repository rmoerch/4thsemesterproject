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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Hero"))
        {
            gM.MaxHP += 100f;
            Destroy(gameObject);
        }
    }
}
