using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
    public GameObject chestEffect;
    public GameObject[] itemsToSpawn;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Hero"))
        {
            Invoke("ChestAnimation", 0f);
            Invoke("SpawnAfterDelay", 1.5f);
        }
    }

    private void ChestAnimation()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1.6f);
        GameObject effect = Instantiate(chestEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    private void SpawnAfterDelay()
    {
        int randomIndex = Random.Range(0, itemsToSpawn.Length);
        GameObject clone = Instantiate(itemsToSpawn[randomIndex], transform.position, Quaternion.identity);
    }

}
