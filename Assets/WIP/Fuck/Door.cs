using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private KeyManager keyManager;

    void Start()
    {
        keyManager = GameObject.FindGameObjectWithTag("Hero").GetComponent<KeyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            for (int i = 0; i < keyManager.keySlot.Length; i++)
            {
                if (keyManager.isFull[i] == true)
                {
                    Destroy(gameObject);
                    Destroy(GetComponent<KeySlot>());
                    Destroy(GameObject.Find("keyIcon"));
                }
            }

        }
    }
}
