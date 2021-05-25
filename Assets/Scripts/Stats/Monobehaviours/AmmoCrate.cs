using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField]
    int ammoRestore;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            //collision.gameObject.GetComponentInParent<GunAmmo>().PickUpAmmo(ammoRestore);
            Destroy(gameObject);
        }

    }

}
