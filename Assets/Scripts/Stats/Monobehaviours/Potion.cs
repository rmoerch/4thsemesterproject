﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
<<<<<<< Updated upstream
    void OnTriggerEnter2D(Collider2D collision)
=======
    [SerializeField]
    float healthRestore;

    private Inventory1 inventory1;
    public GameObject itemButton;

    private void Start()
    {
        inventory1 = GameObject.FindGameObjectWithTag("Hero").GetComponent<Inventory1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
>>>>>>> Stashed changes
    {
        if (collision.CompareTag("Hero"))
        {
            collision.gameObject.GetComponentInParent<PlayerHP>().GetHP(20);
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < inventory1.slots.Length; i++)
            {
                if (inventory1.isFull[i] == false)
                {
                    inventory1.isFull[i] = true;
                    Instantiate(itemButton, inventory1.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }

            }
        }
    }

}
