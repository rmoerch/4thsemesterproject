using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private KeyManager keyHolder;
    public GameObject keyIcon;

    private void Start()
    {
        keyHolder = GameObject.FindGameObjectWithTag("Hero").GetComponent<KeyManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < keyHolder.keySlot.Length; i++)
        {
            if (keyHolder.isFull[i] == false)
            {
                keyHolder.isFull[i] = true;
                Instantiate(keyIcon, keyHolder.keySlot[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }

}
