using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp1 : MonoBehaviour
{
    private Inventory1 inventory1;
    public GameObject itemButton;
    private bool isOpen = false;

    private void Start()
    {
        inventory1 = GameObject.FindGameObjectWithTag("Hero").GetComponent<Inventory1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hero") && isOpen == false)
        {
            isOpen = true;
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


